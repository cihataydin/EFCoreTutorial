using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCoreTutorail.Data.Context;
using EFCoreTutorail.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EFCoreTutorial.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public StudentController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        // GET: api/values
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var student =  await dbContext.Students.ToListAsync();

            return Ok(student);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] string value)
        {
            var student = new Student()
            {
                FirstName = "Cihat",
                LastName = "Aydın",
                StudentAddress = new StudentAddress()
                {
                    City = "İstanbul",
                    Country = "Türkiye",
                    District = "Kadıköy",
                    FullAddress = "X sokak, No: y"

                }
            };

            var result = await dbContext.AddAsync(student);
            await dbContext.SaveChangesAsync();

            return Ok("test");
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
