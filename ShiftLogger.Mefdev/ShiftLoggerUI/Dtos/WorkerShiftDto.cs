namespace ShiftLogger.Mefdev.ShiftLoggerUi.Dtos;

public record WorkerShiftDto(int Id, string Name, DateTime Start,  DateTime End, TimeSpan Duration=default);