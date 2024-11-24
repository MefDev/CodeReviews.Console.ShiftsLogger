using Microsoft.AspNetCore.Mvc;
using ShiftLogger.Mefdev.ShiftLoggerApi.Models;
using ShiftLogger.Mefdev.ShiftLoggerApi.Services;

namespace ShiftLogger.Mefdev.ShiftLoggerApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class WorkerShiftController : ControllerBase
{
    private readonly WorkerShiftService _shiftService;
    

    public WorkerShiftController(WorkerShiftService shiftService)
    {
        _shiftService = shiftService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<WorkerShiftDto>>> GetShifts()
    {
        try
        {
            var workerShifts = await _shiftService.GetWorkerShifts();
            if(workerShifts is null)
            {
                return NotFound(workerShifts);
            }
            return Ok(WorkerShiftMapper.ShiftsToDTO(workerShifts));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<WorkerShiftDto>> GetShift(int id)
    {
        try
        {
            var shift = await _shiftService.GetWorkerShift(id);
            if (shift is null)
            {
                return NotFound(shift);
            }
            return WorkerShiftMapper.ShiftToDTO(shift);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
        
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutWorkerShift(int id, WorkerShiftDto shiftDto)
    {
        try
        {
            if (id != shiftDto.Id)
            {
                return BadRequest();
            }
            var shift = WorkerShiftMapper.DTOtoShift(shiftDto);
            var shiftToUpdate = await _shiftService.UpdateWorkerShift(id, shift);
            if(shiftToUpdate is null)
            {
                return NotFound();
            }
            return NoContent();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost]
    public async Task<ActionResult<WorkerShiftDto>> PostTodoItem(WorkerShiftDto shiftDto)
    {
        try
        {
            var shift = WorkerShiftMapper.DTOtoShift(shiftDto);
            var createdShift = await _shiftService.CreateWorkerShift(shift);
            var newShiftDto = WorkerShiftMapper.ShiftToDTO(createdShift);
            return Ok(newShiftDto);
        }
        catch
        {
            return BadRequest();
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteShift(int id)
    {
        try
        {
            var todoItem = await _shiftService.DeleteWorkerShift(id);
            if (todoItem == false)
            {
                return NotFound();
            }
            return NoContent();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }    
}