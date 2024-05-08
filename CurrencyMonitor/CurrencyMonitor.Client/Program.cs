using AutoMapper;
using CurrencyMonitor.Client.Controllers;
using CurrencyMonitor.Core.Interfaces;
using Quartz;

namespace CurrencyMonitor.Client;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        // Add Quartz services
        builder.Services.AddQuartz(q =>
        {
            
            //Use a persistent job store
            q.UsePersistentStore(s =>
            {
                s.UseProperties = true;
                s.RetryInterval = TimeSpan.FromSeconds(15);
                s.PerformSchemaValidation = true;
                s.UseSqlServer("Server=.;Database=CurrencyDb;Trusted_Connection=true;TrustServerCertificate=True;");

                //s.UseBinarySerializer();
            });


            q.AddTrigger(opts => opts
                .ForJob(nameof(FetchCurrencyRatesJob))
                .WithIdentity("FetchCurrencyRatesTrigger")
                .WithCronSchedule("0 0/1 * 1/1 * ? *")); // Cron expression for every minute
        });

        builder.Services.AddQuartzHostedService(q => q.WaitForJobsToComplete = true);


        builder.Services.AddScoped<ICurrencyRatesService, CurrencyController>();


        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        app.UseAuthorization();


        app.MapControllers();


        app.Run();
    }
}