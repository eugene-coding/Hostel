using Microsoft.Extensions.Configuration;

namespace DatabaseTest.Helpers;

internal static class ConfigurationHelper
{
    public static string GetTestConnectionString()
    {
        const string connectionStringName = "TestDatabase";

        return GetConfiguration().GetConnectionString(connectionStringName)
            ?? throw new NullReferenceException(
                $"Не удалось найти строку подключения под названием {connectionStringName}.");
    }

    private static IConfigurationRoot GetConfiguration()
    {
        var configBuilder = new ConfigurationBuilder();
        configBuilder.AddJsonFile("appsettings.json", false, true);

        return configBuilder.Build();
    }
}
