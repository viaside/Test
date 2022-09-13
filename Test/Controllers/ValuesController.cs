using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Test.Models;
using Newtonsoft;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        RGDialogsClients clients = new RGDialogsClients();

        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<RGDialogsClients> Get()
        {
            return clients.Init();
        }

        // GET api/<ValuesController>/5
        [HttpGet("{idClient}")]
        public List<string> Get(Guid idClient)
        {
            var idrgDialogs = clients.Init().Where(d => d.IDClient == idClient);

            var id = idrgDialogs.Select(p => new { p, p.IDRGDialog });

            List<string> strings = new List<string>();

            foreach(var i in id)
            {
                strings.Add(i.IDRGDialog.ToString());
            }
            return strings;
        }
    }
}
