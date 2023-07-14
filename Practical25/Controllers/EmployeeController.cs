using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Practical25.MediatorClass;
using Practical25.Models;
using Practical25.Validate;

namespace Practical25.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IMediator _mediator;
        public EmployeeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(Employee employee)
        {
            ValidateEmployee validation = new ValidateEmployee();
            ValidationResult result = validation.Validate(employee);
            if (result.IsValid)
            {
                CreateEmployee command = new CreateEmployee() { Name = employee.Name, Email = employee.Email, Salary = employee.Salary, DepartmentId = employee.DepartmentId };

                return Ok(await _mediator.Send(command));
            }
            return BadRequest(result.Errors.Select(item => new { item.PropertyName, item.ErrorMessage }));

        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _mediator.Send(new GetAllEmployees())); ;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var emp = await _mediator.Send(new GetEmployeeById { Id = id });
            if (emp != null)
            {
                return Ok(emp);
            }
            else
            {
                return NotFound("Employee with this id could not be found");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Employee employee)
        {
            ValidateEmployee validation = new ValidateEmployee();
            ValidationResult result = validation.Validate(employee);
            if (result.IsValid)
            {
                UpdateEmployee command = new UpdateEmployee() { Id = id, Name = employee.Name, Email = employee.Email, Salary = employee.Salary, DepartmentId = employee.DepartmentId };

                return Ok(await _mediator.Send(command));
            }
            return BadRequest(result.Errors.Select(item => new { item.PropertyName, item.ErrorMessage }));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = GetById(id);
            if (result != null)
            {
                DeleteEmployee command = new DeleteEmployee() { Id = id };

                return Ok(await _mediator.Send(command));
            }
            return BadRequest();
        }
    }
}
