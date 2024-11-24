using Microsoft.Extensions.DependencyInjection;
using ShiftLogger.Mefdev.ShiftLoggerUi;
using ShiftLogger.Mefdev.ShiftLoggerUi.Inputs;
using ShiftLogger.Mefdev.ShiftLoggerUi.Services;
using ShiftLogger.Mefdev.ShiftLoggerUi.Controllers;

var serviceProvider = new ServiceCollection()
               .AddScoped<ManageShifts>() 
               .AddScoped<UserInput>()
               .AddScoped<WorkerShiftController>()
               .AddScoped<UserInterface>()
               .BuildServiceProvider();

var app = serviceProvider.GetRequiredService<UserInterface>();
await app.MainMenu();