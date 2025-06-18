namespace TLSPL_ProdutBackEnd.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TLSPL_ProdutBackEnd.Models;
using TLSPL_ProdutBackEnd.Data;

[Route("api/[controller]")]
[ApiController]
public class EmployeesController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public EmployeesController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: api/employees
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
    {
        return await _context.Employees.ToListAsync();
    }

    // GET: api/employees/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Employee>> GetEmployee(int id)
    {
        var employee = await _context.Employees.FindAsync(id);
        if (employee == null)
            return NotFound();

        return employee;
    }

    // POST: api/employees
    [HttpPost]
    public async Task<IActionResult> CreateEmployee(Employee employee)
    {
        ConvertDateTimesToUtc(employee);

        _context.Employees.Add(employee);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetEmployee), new { id = employee.EmployeeId }, employee);
    }

    private void ConvertDateTimesToUtc(object entity)
    {
        var properties = entity.GetType().GetProperties()
            .Where(p => p.PropertyType == typeof(DateTime) || p.PropertyType == typeof(DateTime?));

        foreach (var property in properties)
        {
            var value = property.GetValue(entity);
            if (value == null) continue;

            if (property.PropertyType == typeof(DateTime))
            {
                var dt = (DateTime)value;
                if (dt.Kind == DateTimeKind.Unspecified)
                    dt = DateTime.SpecifyKind(dt, DateTimeKind.Utc);
                else if (dt.Kind == DateTimeKind.Local)
                    dt = dt.ToUniversalTime();

                property.SetValue(entity, dt);
            }
            else if (property.PropertyType == typeof(DateTime?))
            {
                var dtNullable = (DateTime?)value;
                if (dtNullable.HasValue)
                {
                    var dt = dtNullable.Value;
                    if (dt.Kind == DateTimeKind.Unspecified)
                        dt = DateTime.SpecifyKind(dt, DateTimeKind.Utc);
                    else if (dt.Kind == DateTimeKind.Local)
                        dt = dt.ToUniversalTime();

                    property.SetValue(entity, (DateTime?)dt);
                }
            }
        }
    }


    // PUT: api/employees/5
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateEmployee(int id, Employee updated)
    {
        if (id != updated.EmployeeId)
            return BadRequest();

        var existing = await _context.Employees.FindAsync(id);
        if (existing == null)
            return NotFound();

        // update fields
        _context.Entry(existing).CurrentValues.SetValues(updated);
        existing.UpdatedAt = DateTime.UtcNow;

        await _context.SaveChangesAsync();
        return NoContent();
    }

    // DELETE: api/employees/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteEmployee(int id)
    {
        var employee = await _context.Employees.FindAsync(id);
        if (employee == null)
            return NotFound();

        _context.Employees.Remove(employee);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}

