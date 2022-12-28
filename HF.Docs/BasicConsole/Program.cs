// See https://aka.ms/new-console-template for more information
using Hangfire;
using Hangfire.SqlServer;

Console.WriteLine("Hello, World!");

GlobalConfiguration.Configuration
.SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
.UseColouredConsoleLogProvider()
.UseSimpleAssemblyNameTypeSerializer()
.UseRecommendedSerializerSettings()
.UseSqlServerStorage("Server=localhost\\sql2019e;Database=Hangfire.Sample; Integrated Security = True; ",
  new SqlServerStorageOptions
    {
        CommandBatchMaxTimeout = TimeSpan.FromMinutes(5),
        SlidingInvisibilityTimeout = TimeSpan.FromMinutes(5),
        QueuePollInterval = TimeSpan.Zero,
        UseRecommendedIsolationLevel = true
    });

BackgroundJob.Enqueue(() => Console.WriteLine("Hello, Job!"));
BackgroundJob.Schedule(() => Console.WriteLine("Hello from Sechedule"), TimeSpan.FromSeconds(10));

using (var server = new BackgroundJobServer())
{
    Console.ReadLine();
}
