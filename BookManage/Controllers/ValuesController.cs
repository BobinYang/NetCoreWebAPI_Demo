using System.IO;
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
        private static Dictionary<string, AddRequest> DB = new Dictionary<string, AddRequest>();
        [HttpPost]
        public AddResponse Post([FromBody] AddRequest req)
        {
            AddResponse resp = new AddResponse();
            try
            {
                DB.Add(req.ISBN, req);
                resp.ISBN = req.ISBN;
                resp.message = "交易成功";
                resp.result = "S";

            }
            catch (Exception ex)
            {
                Console.Write(ex);

                resp.ISBN = "";
                resp.message = "交易失败";
                resp.result = "F";
            }
            return resp;
        }

        // 接口样例：
        // {
        // "ISBN": "1",
        // "name": "1",
        // "price": "1",
        // "date": "20200219",
        // "authors": [
        //     {
        //         "name": "Jerry",
        //         "sex": "M",
        //         "birthday": "18888515"
        //     },
        //     {
        //         "name": "Tom",
        //         "sex": "M",
        //         "birthday": "18440101"
        //     }
        //     ]
        // }

    }
}
