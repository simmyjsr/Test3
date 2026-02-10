using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Test3.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeesController : ControllerBase
    {
        private readonly ILogger<EmployeesController> _logger;

        public EmployeesController(ILogger<EmployeesController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetEmployees")]
        public ActionResult<IEnumerable<Employee>> Get()
        {
            var employees = new[]
            {
                new Employee(1, "Alice", "Smith", "alice.smith@example.com", "Developer", DateTime.UtcNow.AddYears(-3)),
                new Employee(2, "Bob", "Johnson", "bob.johnson@example.com", "Manager", DateTime.UtcNow.AddYears(-5)),
                new Employee(3, "Carol", "Williams", "carol.williams@example.com", "QA Engineer", DateTime.UtcNow.AddYears(-1)),
                new Employee(4, "David", "Brown", "david.brown@example.com", "Support", DateTime.UtcNow.AddMonths(-6))
            };

            return Ok(employees);
        }

        [HttpGet("company", Name = "GetCompany")]
        public ActionResult<Company> GetCompany()
        {
            var company = new Company(
                1,
                "Contoso Ltd.",
                "123 Main St, Anytown, USA",
                "info@contoso.com",
                "+1-555-0100",
                DateTime.UtcNow.AddYears(-12),
                new[]
                {
                    new Employee(1, "Alice", "Smith", "alice.smith@example.com", "Developer", DateTime.UtcNow.AddYears(-3)),
                    new Employee(2, "Bob", "Johnson", "bob.johnson@example.com", "Manager", DateTime.UtcNow.AddYears(-5))
                }
            );

            return Ok(company);
        }
    }

    public record Employee(
        int Id,
        string FirstName,
        string LastName,
        string Email,
        string Position,
        DateTime HireDate
    );

    public record Company(
        int Id,
        string Name,
        string Address,
        string ContactEmail,
        string Phone,
        DateTime Founded,
        Employee[] Employees
    );
}