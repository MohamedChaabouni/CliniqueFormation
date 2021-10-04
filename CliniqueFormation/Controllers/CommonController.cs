using Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace CliniqueFormation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommonController : ControllerBase
    {
        private readonly DbContextOptions options;

        public CommonController([NotNull] DbContextOptions options)
        {
            this.options = options;
        }
        [HttpGet]
        public IActionResult Get()
        {
            Parallel.Invoke(
            () =>
            {
                using (ApplicationDbContext Db = new ApplicationDbContext(options))
                {

                }
            }, () =>
            {
                using (ApplicationDbContext Db = new ApplicationDbContext(options))
                {

                }
            }, () =>
            {
                using (ApplicationDbContext Db = new ApplicationDbContext(options))
                {

                }
            }, () =>
            {
                using (ApplicationDbContext Db = new ApplicationDbContext(options))
                {

                }
            }, () =>
            {
                using (ApplicationDbContext Db = new ApplicationDbContext(options))
                {

                }
            }, () =>
            {
                using (ApplicationDbContext Db = new ApplicationDbContext(options))
                {

                }
            });

            return Ok();
        }
    }
}
