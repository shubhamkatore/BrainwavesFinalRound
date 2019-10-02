using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SG.SwiftMatching.Models;
using SG.SwiftMatching.Web.App_Code;

namespace SG.SwiftMatching.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            //var clientFile=Environment.CurrentDirectory+"\\Data\\ClientProposedDataforSampleData\\";
            //var resDict = new List<List<List<string>>>();
            //for (int i = 1; i < 11; i++)
            //{
            //    resDict.Add(Match.MatchOperation(clientFile+i.ToString()+ "_message.txt"));
            //}
            //foreach(var masterList in resDict)
            //{
            //    foreach (var parentList in masterList)
            //    {
            //        var test = parentList;
            //    }
            //}

            //var matchData = Match.MatchOperation(clientFile);
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
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
