using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;

namespace Syncer.Controllers
{
    public class Music
    {
        public string Name { get; set; }
        public string Album { get; set; }
        public string Artist { get; set; }
    }
    [Route("api/Status")]
    public class StatusController : ApiController
    {
        private static Status status = new Status();
        private static Music music = new Music();
        // GET: api/Status
        [HttpGet]
        public Music Get()
        {
            return music;
        }
        [HttpGet]
        public IEnumerable<string> Get(string stat)
        {
            return new string[] { status.stat };
        }

        // PUT: api/Status/5
        [HttpPost]
        [Route("StatUpdate")]
        public void Stat([FromBody]Status s)
        {
            status = s;
        }

        [HttpPost]
        public void Post([FromBody]Music m)
        {
            var oldMusic = music;
            try
            {
                music = m;
            }
            catch
            {
                music = oldMusic;
            }
        }

    }
}
