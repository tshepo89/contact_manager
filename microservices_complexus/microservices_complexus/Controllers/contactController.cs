using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using contact_manager;

namespace microservices_complexus.Controllers
{
    public class contactController : ApiController
    {
        // GET: api/contact
        public IEnumerable<customer> Get()
        {
            using (customer_manager_dbEntities entities = new customer_manager_dbEntities())
            {
                return entities.customers.ToList();
            }
        }


        //// GET: api/contact
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET: api/contact/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/contact
        public void Post([FromBody]customer value)
        {
            try
            {
                using (customer_manager_dbEntities entities = new customer_manager_dbEntities())
                {
                    entities.customers.Add(value);
                    entities.SaveChanges();
                }
            }
            catch (Exception ex) { }
        }

        // PUT: api/contact/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/contact/5
        public void Delete(int id)
        {
        }
    }
}
