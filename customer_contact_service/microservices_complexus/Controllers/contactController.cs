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
        // POST: api/contact
        public void Post([FromUri]customer value){
            try{
                using (customer_manager_dbEntities entities = new customer_manager_dbEntities()){
                    entities.customers.Add(value);
                    entities.SaveChanges();
                }
            }
            catch (Exception ex) { }
        }

        [HttpPost, Route ("api/contact/add_customer_contact/{name=name}/{email=email}/{mobile=mobile}")]
        public void Post([FromBody]customer_contact value){
            try{
                using (customer_manager_dbEntities entities = new customer_manager_dbEntities()){
                    entities.customer_contact.Add(value);
                    entities.SaveChanges();
                }
            }
            catch (Exception ex) { }
        }

        // GET: api/contact
        public IEnumerable<customer> Get(){
            using (customer_manager_dbEntities entities = new customer_manager_dbEntities()){
                return entities.customers.ToList();
            }
        }

        // GET: api/contact/5
        public IEnumerable<customer> Get(int id){
            using (customer_manager_dbEntities entities = new customer_manager_dbEntities()){
                return entities.customers.ToList();
            }
        }

        // PUT: api/contact/5
        public void Put(int id, [FromBody]customer value){}

        // PUT: api/contact/5
        public void Put(int id, [FromBody]customer_contact value) { }

        // DELETE: api/contact/5
        public void Delete(int id){}
    }
}
