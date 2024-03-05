# Project Function Task

ProjectFunctionTask is an Azure Function C# Application that takes data from Azure SQL Database and forwards it to Auzre Cosmos DB.

The purpose of this project is to make a backup snapshot every X interval of time with TimeTrigger function that can be edited direactly in code.

Required Nuget Pacakge for this projec are:

- **Microsoft.EntityFrameworkCore.SqlServer**

- **Microsoft.EntityFrameworkCore.Cosmos**


Please add the following values to your **local.settings.json** :

- "SqlConnectionString": "Your_Sql_Connection_String"

- "CosmosUrl": "Your_Cosmos_Uri"

- "CosmosKey": "Your_Cosmos_Db_Key"

- "CosmosDatabaseName": "Your_Cosmos_Database"

