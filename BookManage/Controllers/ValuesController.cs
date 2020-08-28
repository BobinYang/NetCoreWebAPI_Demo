using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BookManage.Models;

namespace BookManage.Controllers
{
    [ApiController]
    [Route("book/[controller]")]
    public class ValuesController : ControllerBase
    {
        [HttpPost]
        public AddResponse Post([FromBody] AddRequest req)
        {
            AddResponse resp = new AddResponse();
            try
            {
                resp.ISBN = req.ISBN;
                resp.result = "F";

            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
            return resp;
        }

    }
}
