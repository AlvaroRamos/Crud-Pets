using Backend_Mascota.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Backend_Mascota.Controllers
{
    [EnableCors(origins:"*", headers:"*", methods:"*")]
    public class mascotaController : ApiController
    {
        // GET: api/mascota
        public IEnumerable<mascota> Get()
        {
            gestorMascota gMascota = new gestorMascota();
            return gMascota.getMascotas();
        }

        // GET: api/mascota/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/mascota
        public bool Post([FromBody] mascota Mascota)
        {
            gestorMascota gMascota = new gestorMascota();
            bool response = gMascota.addMascota(Mascota);

            return response;
        }

        // PUT: api/mascota/5
        public bool Put(int id, [FromBody] mascota Mascota)
        {
            gestorMascota gMascota = new gestorMascota();
            bool response = gMascota.updateMascota(id, Mascota);

            return response;
        }

        // DELETE: api/mascota/5
        public bool Delete(int id)
        {
            gestorMascota gMascota = new gestorMascota();
            bool response = gMascota.deleteMascota(id);

            return response;
        }
    }
}
