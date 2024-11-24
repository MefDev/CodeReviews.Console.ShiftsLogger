namespace ShiftLogger.Mefdev.ShiftLoggerApi.Models;

public record WorkerShiftDto(int Id, string Name, DateTime Start,  DateTime End, TimeSpan? Duration=null);