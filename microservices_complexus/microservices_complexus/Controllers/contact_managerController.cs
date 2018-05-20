using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using contact_manager;

namespace microservices_complexus.Controllers
{
    public class contact_managerController : ApiController
    {
        // GET: api/contact_manager_
        public IEnumerable<customer> Get()
        {
            using (customer_manager_dbEntities entities = new customer_manager_dbEntities())
            {
                return entities.customers.ToList();
            }
        }

        //public IEnumerable<customer> Get()
        //{
        //    using (customer_manager_dbEntities entities = new customer_manager_dbEntities())
        //    {
        //        return entities.customers.ToList();
        //    }
        //}
    }
}
