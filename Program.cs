using DbUp;
using Microsoft.Extensions.Configuration;
using System.Reflection;

var config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", true, true)
    .Build();

var connectionString =
        args.FirstOrDefault()
        ?? config.GetConnectionString("Default");

var createDataBase = Convert.ToBoolean(config["DbBaseConfig:CreateDataBase"]);
if (createDataBase)
{
    EnsureDatabase.For.SqlDatabase(connectionString);
}

var upgrader =
    DeployChanges.To
        .SqlDatabase(connectionString)
        .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly())
        .LogToConsole()
        .Build();

var result = upgrader.PerformUpgrade();

if (!result.Successful)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine(result.Error);
    Console.ResetColor();
#if DEBUG
    Console.ReadLine();
#endif
    return -1;
}

Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("Success!");
Console.ResetColor();

return 0;