using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SG.SwiftMatching.Database;
using SG.SwiftMatching.Models;
using SG.SwiftMatching.Web.App_Code;

namespace SG.SwiftMatching.Web.Controllers
{
    [EnableCors("SiteCorsPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class SwiftMatchController : ControllerBase
    {
        // GET: api/SwiftMatch
        [HttpGet]
        public IEnumerable<string> Get()
        {
            var clientFile = Environment.CurrentDirectory + "\\Data\\ClientProposedDataforSampleData\\";
            var resDict = new List<List<List<string>>>();
            for (int i = 1; i < 18; i++)
            {
                resDict.Add(Match.MatchOperation(clientFile + i.ToString() + "_message.txt"));
            }
            foreach (var masterList in resDict)
            {
                foreach (var parentList in masterList)
                {
                    var Parameters = new Dictionary<string, string> {
                        { "@SGRef", parentList[0] },
                        { "@CLRef", parentList[1] },
                        { "@Result", parentList[2] }
                    };
                    var DataTable = SQLOperation.ExecuteCommand(Startup.ConnectionString, "insertOneToOne", Parameters);
                }
            }
            return new string[] { "value1", "value2" };
        }

        // GET: api/SwiftMatch/onetoone
        [HttpGet("onetoone", Name = "GetO")]
        public string GetOneToOne()
        {
            var DataTable = SQLOperation.ExecuteCommand(Startup.ConnectionString, "getonetoone");
            return JsonConvert.SerializeObject(DataTable);
        }

        // GET: api/SwiftMatch/onetoone
        [HttpGet("forcematch/{SGref}/{CLRef}", Name = "ForceMatch")]
        public string ForceMatch(string SGref,string CLRef)
        {
            var parameters = new Dictionary<string, string> {
                { "@SGRef", SGref},
                { "@CLRef", CLRef}
            };
            var DataTable = SQLOperation.ExecuteCommand(Startup.ConnectionString, "forceMatch", parameters);
            return JsonConvert.SerializeObject(DataTable);
        }

        // GET: api/SwiftMatch/onetoone
        [HttpGet("onetooneDetail", Name = "GetOD")]
        public string DetailGetOneToOne()
        {
            var clientFile = Environment.CurrentDirectory + "\\Data\\ClientProposedDataforSampleData\\";
            var resDict = new List<List<List<Message>>>();
            for (int i = 1; i < 18; i++)
            {
                resDict.Add(Match.MatchOperationFullData(clientFile + i.ToString() + "_message.txt"));
            }
            var uiData = new List<Message>();
            foreach (var masterList in resDict)
                foreach (var parentList in masterList)
                    foreach (var item in parentList)
                        uiData.Add(item);
            return JsonConvert.SerializeObject(uiData);
        }

        // GET: api/SwiftMatch/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/SwiftMatch
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/SwiftMatch/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
