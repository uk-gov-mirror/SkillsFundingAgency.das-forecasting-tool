﻿using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using Newtonsoft.Json;
using SFA.DAS.Forecasting.AcceptanceTests.Services.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace SFA.DAS.Forecasting.AcceptanceTests.Services
{
    public class AzureTableService
    {
        private readonly CloudTable _table;

        public AzureTableService(string connectionString, string tableName)
        {
            var storageAccount = CloudStorageAccount.Parse(connectionString);
            var tableClient = storageAccount.CreateCloudTableClient();
            _table = tableClient.GetTableReference(tableName);
        }

        internal void EnsureExists()
        {
            if (!_table.Exists())
            {
                _table.Create();
            }
        }

        internal void ClearTable()
        {
            _table.DeleteIfExists();
        }

        internal void DeleteEntities(string partitionKey)
        {
            var query = new TableQuery<TableRow>().Where(TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, partitionKey));
            foreach (var item in _table.ExecuteQuery(query))
            {
                var oper = TableOperation.Delete(item);
                _table.Execute(oper);
            }
            Thread.Sleep(500); // retry...
        }

        internal void DeleteEntitiesStartingWith(string partitionKey)
        {
            var query = new TableQuery<TableRow>();
            foreach (var item in _table.ExecuteQuery(query).Where(m => m.PartitionKey.StartsWith(partitionKey)))
            {
                var oper = TableOperation.Delete(item);
                _table.Execute(oper);
            }
            Thread.Sleep(500); // retry...
        }

        internal IList<T> GetRecords<T>(string partitionKey) 
			where T : class 
        {
            var query = new TableQuery<TableRow>().Where(TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, partitionKey));

            return _table.ExecuteQuery(query)
                .Select(entity => JsonConvert.DeserializeObject<T>(entity.Data))
                .ToList();
        }

        internal IList<T> GetRecordsStartingWith<T>(string partitionKey)
            where T : class
        {
            var query = new TableQuery<TableRow>();

            return _table.ExecuteQuery(query)
                .Where(m => m.PartitionKey.StartsWith(partitionKey))
                .Select(entity => JsonConvert.DeserializeObject<T>(entity.Data))
                .ToList();
        }
    }
}