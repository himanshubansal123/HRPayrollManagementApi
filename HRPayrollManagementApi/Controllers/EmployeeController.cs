using HRPayrollManagementApi.Application.DTOs;
using HRPayrollManagementApi.Application.Interfaces.Employees;
using Microsoft.AspNetCore.Mvc;

namespace HRPayrollManagementApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController(IEmployeeService service) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<EmployeeDto>>>GetAll(CancellationToken ct) => Ok(await service.GetAllAsync(ct));

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<EmployeeDto>> Get(Guid id, CancellationToken ct) 
            => (await service.GetAsync(id, ct)) is { } dto ? Ok(dto) : NotFound();

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] EmployeeDto dto, CancellationToken ct)
        {
            var id = await service.CreateAsync(dto with { Id = null},ct);
            return CreatedAtAction(nameof(Get), new { id } , id);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult> Update (Guid id, [FromBody] EmployeeDto dto, CancellationToken ct)
        {
            await service.UpdateAsync(id, dto, ct);
            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> Delete(Guid id, CancellationToken ct)
        {
            await service.DeleteAsync(id, ct);
            return NoContent();
        }

    }
}
