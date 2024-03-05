using Function.Data;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Cosmos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Function.Entities;
using Task = System.Threading.Tasks.Task;

namespace Function
{
    public class Function1
    {
        private readonly ILogger _logger;

        public Function1(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<Function1>();
        }

        private static async Task InsertProjectToCosmosDb(Project project)
        {

            using (var context = new CosmosContext(Environment.GetEnvironmentVariable("CosmosUrl"), Environment.GetEnvironmentVariable("CosmosKey"), Environment.GetEnvironmentVariable("CosmosDatabaseName")))
            {
                await context.Projects.AddAsync(project);
                await context.SaveChangesAsync();
            }
        }

        [Function("Function1")]
        public async Task Run([TimerTrigger("0 */1 * * * *")] TimerInfo myTimer)
        {
            _logger.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");
            _logger.LogInformation(Environment.GetEnvironmentVariable("SqlConnectionString"));

            if (myTimer.ScheduleStatus is not null)
            {
                _logger.LogInformation($"Next timer schedule at: {myTimer.ScheduleStatus.Next}");
            }
            try
            {
                List<Project> projects;

                using (var sqlDbContext = new SqlDbContext(Environment.GetEnvironmentVariable("SqlConnectionString")))
                {
                    projects = await sqlDbContext.Projects.Include(t => t.Tasks).ToListAsync();
                }

                foreach (var project in projects)
                {
                    await InsertProjectToCosmosDb(project);
                }
            }
            catch(Exception ex)
            {
                _logger.LogInformation($"Error occured: ${ex.Message}");
            }
           
        }
    }
}
