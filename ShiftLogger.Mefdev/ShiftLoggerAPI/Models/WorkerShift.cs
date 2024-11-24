namespace ShiftLogger.Mefdev.ShiftLoggerApi.Models;

public class WorkerShift
{
    public int Id { get; set; }
    public string EmployeeName { get; set; } = null!;
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}