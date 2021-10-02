using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LogicLayer;


namespace InventoryProject.Controllers
{
    public class ValuesController : ApiController
    {
        Database_Access db = new Database_Access();
        public List<InventoryEntity> entity { get; set; }
        // GET api/values
        public List<InventoryEntity> Get()
        {
            entity = db.GetInventoryEntities();
            return entity;
        }

        // GET api/values/5
        public List<InventoryEntity> Get(int id)
        {
            entity = db.GetInventoryEntities_byid(id);
            return entity;
        }

        // POST api/values
        public void Post([FromBody]InventoryEntity inventory)
        {
            
            db.Insert_Data(Convert.ToInt32(inventory.ID), inventory.Name, inventory.Info, inventory.MD, inventory.ED, Convert.ToInt32(inventory.Price));
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]InventoryEntity inventory)
        {
            db.Update_Data(Convert.ToInt32(inventory.ID), inventory.Name, inventory.Info, inventory.MD, inventory.ED, Convert.ToInt32(inventory.Price));

        }

        // DELETE api/values/5
        public void Delete(int id)
        {
            db.Delete_Data(id);
        }
    }
}
