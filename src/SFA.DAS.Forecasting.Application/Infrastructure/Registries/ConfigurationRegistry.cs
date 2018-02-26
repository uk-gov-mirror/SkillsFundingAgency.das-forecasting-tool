﻿using System;
using System.Configuration;
using System.Threading.Tasks;
using Microsoft.Azure;
using Microsoft.Azure.KeyVault;
using Microsoft.Azure.Services.AppAuthentication;
using SFA.DAS.Configuration;
using SFA.DAS.Configuration.AzureTableStorage;
using SFA.DAS.EAS.Account.Api.Client;
using SFA.DAS.Forecasting.Application.Infrastructure.Configuration;
using StructureMap;

namespace SFA.DAS.Forecasting.Application.Infrastructure.Registries
{
    public class ConfigurationRegistry : Registry
    {
        public ConfigurationRegistry()
        {
            var config = GetConfiguration();
            ForSingletonOf<IApplicationConfiguration>().Use(config);
        }

        private IApplicationConfiguration GetConfiguration()
        {
            var configuration = new ApplicationConfiguration
            {
                DatabaseConnectionString = GetConnectionString("DatabaseConnectionString"),
                EmployerConnectionString = GetConnectionString("EmployerConnectionString"),
                StorageConnectionString = GetConnectionString("StorageConnectionString"),
                Hashstring = GetAppSetting("HashString", true),
                AllowedHashstringCharacters = GetAppSetting("AllowedHashstringCharacters", true),
                NumberOfMonthsToProject = int.Parse(GetAppSetting("NumberOfMonthsToProject", false) ?? "0"),
                SecondsToWaitToAllowProjections = int.Parse(GetAppSetting("SecondsToWaitToAllowProjections", false) ?? "0"),
                BackLink = GetAppSetting("BackLink", false),
                LimitForecast = Boolean.Parse(GetAppSetting("LimitForecast", false) ?? "false")
            };

            if (IsDevEnvironment)
                SetApiConfiguration(configuration);
            else
                SetApiConfigurationTableStorage(configuration);

            return configuration;
        }

        private void SetApiConfiguration(ApplicationConfiguration config)
        {
            config.AccountApi = new AccountApiConfiguration
            {
                Tenant = CloudConfigurationManager.GetSetting("AccountApi-Tenant"),
                ClientId = CloudConfigurationManager.GetSetting("AccountApi-ClientId"),
                ClientSecret = CloudConfigurationManager.GetSetting("AccountApi-ClientSecret"),
                ApiBaseUrl = CloudConfigurationManager.GetSetting("AccountApi-ApiBaseUrl"),
                IdentifierUri = CloudConfigurationManager.GetSetting("AccountApi-IdentifierUri")
            };

            config.PaymentEventsApi = new PaymentsEventsApiConfiguration
            {
                ApiBaseUrl = GetAppSetting("PaymentsEvent-ApiBaseUrl", true),
                ClientToken = GetAppSetting("PaymentsEvent-ClientToken", true),
            };
        }

        private void SetApiConfigurationTableStorage(ApplicationConfiguration config)
        {
            config.AccountApi = SetUpConfiguration<AccountApiConfiguration>("SFA.DAS.EmployerAccountAPI");
            config.PaymentEventsApi = SetUpConfiguration<PaymentsEventsApiConfiguration>("SFA.DAS.PaymentsAPI");
        }


        private string KeyVaultBaseUrl => $"https://{CloudConfigurationManager.GetSetting("KeyVaultName")}.vault.azure.net";

        private async Task<string> GetSecret(string secretName)
        {
            var azureServiceTokenProvider = new AzureServiceTokenProvider();
            var keyVaultClient = new KeyVaultClient(new KeyVaultClient.AuthenticationCallback(azureServiceTokenProvider.KeyVaultTokenCallback));
            var secret = await keyVaultClient.GetSecretAsync(KeyVaultBaseUrl, secretName).ConfigureAwait(false);
            return secret.Value;
        }

        public string GetAppSetting(string keyName, bool isSensitive)
        {
            var value = ConfigurationManager.AppSettings[keyName];
            return IsDevEnvironment || !isSensitive
                ? value 
                : GetSecret(keyName).Result;
        }

        public static bool IsDevEnvironment =>
            (ConfigurationManager.AppSettings["EnvironmentName"]?.Equals("DEV") ?? false) ||
            (ConfigurationManager.AppSettings["EnvironmentName"]?.Equals("DEVELOPMENT") ?? false) ||
            (ConfigurationManager.AppSettings["EnvironmentName"]?.Equals("LOCAL") ?? false);

        public string GetConnectionString(string name)
        {
            var connectionString = ConfigurationManager.ConnectionStrings[name]?.ConnectionString;
            if (string.IsNullOrEmpty(connectionString))
                return GetAppSetting(name, true);

            return IsDevEnvironment
                ? connectionString
                : GetSecret(connectionString).Result;
        }

        public TConfig SetUpConfiguration<TConfig>(string serviceName) where TConfig : class
        {
            var environment = Environment.GetEnvironmentVariable("DASENV");
            if (string.IsNullOrEmpty(environment))
            {
                environment = GetAppSetting("EnvironmentName", false);
            }

            var storageConnectionString = GetAppSetting("ConfigurationStorageConnectionString", true);
            var configurationRepository = new AzureTableStorageConfigurationRepository(storageConnectionString);
            var configurationService = new ConfigurationService(configurationRepository,
                new ConfigurationOptions(serviceName, environment, "1.0"));

            var result = configurationService.Get<TConfig>();
            return result;
        }
    }
}
