
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using vehicle_data_access;
using System.Web.Http.Cors;


namespace microservices_complexus.Controllers
{
    public class vehiclesController : ApiController
    {
        [HttpGet, Route("api/vehicles/get_vehicle_price_range/{min_price:double}/{max_price:double}")]
        public IEnumerable<vehicle> get_vehicle_price_range(double min_price, double max_price)
        {
            using (vehicle_entities entities = new vehicle_entities()){
                return entities.vehicles.Where(v => v.price > min_price && v.price < max_price).ToList();
            }
        }

        [Route("api/vehicles/get_vehicle_make_model/{make=make}/{model=model}")]
        [HttpGet]
        public IEnumerable<vehicle> get_vehicle_make_model(string make, string model)
        {
            using (vehicle_entities entities = new vehicle_entities()){
                return entities.vehicles.Where(v => v.make == make || v.model == model).ToList();
            }
        }

        [Route("api/vehicles/get_engine_capacity/{engine:double}")]
        [HttpGet]
        public IEnumerable<vehicle> get_engine_capacity(double engine)
        {
            List<vehicle> vehicles = new List<vehicle>();
            double engine_capacity = 2.0;
            using (vehicle_entities entities = new vehicle_entities()){
                if (engine > engine_capacity)
                    vehicles = entities.vehicles.Where(v => v.engine_capacity > engine_capacity).ToList();
            }
            return vehicles;
        }

        [HttpGet, Route("api/vehicles/get_cylinder_variant/{cylinder_variant:double}")]
        public IEnumerable<vehicle> get_cylinder_variant(double cylinder_variant)
        {
            using (vehicle_entities entities = new vehicle_entities()){
                return entities.vehicles.Where(v => v.cylinder_variant == cylinder_variant).ToList();
            }
        }

        [HttpGet, Route("api/vehicles/get_cylinder")]
        public IEnumerable<vehicle> get_cylinder()
        {
            using (vehicle_entities entities = new vehicle_entities()){
                return entities.vehicles.ToList();
            }
        }

        [HttpGet, Route("api/vehicles/get_08Lcylinder_capacity/{engine:double}/{cylinder:double}")]
        public IEnumerable<vehicle> get_08Lcylinder_capacity(double engine, double cylinder)
        {
            List<vehicle> vehicles = new List<vehicle>();
            
            double cylinder_variantO8L = 0.8;
            using (vehicle_entities entity = new vehicle_entities())
            {
                double cylinder_result = engine / cylinder; // 2L/ 2.5C = 0.8L
                if (cylinder_variantO8L == cylinder_result) //0.8L == 0.8L
                    vehicles = entity.vehicles.Where(v => v.cylinder_variant == cylinder_result).ToList();
            }
            return vehicles;
        }


        // GET: api/vehicle
        public IEnumerable<vehicle> Get()
        {
            using(vehicle_entities entities = new vehicle_entities()) {
                return entities.vehicles.ToList();
            }
        }

        // GET: api/vehicle/5
        public vehicle Get(int id)
        {
            using (vehicle_entities entities = new vehicle_entities()){
                return entities.vehicles.Where(v => v.id == id).FirstOrDefault();
            }
        }

        // POST: api/vehicle
        public void Post([FromBody]vehicle val)
        {
            try{
                using (vehicle_entities entities = new vehicle_entities()){
                    entities.vehicles.Add(val);
                    entities.SaveChanges();
                }
            }
            catch (Exception ex) { }
        }

        // PUT: api/vehicle/5
        public void Put(int id, [FromBody]string value){ }

        // DELETE: api/vehicle/5
        public void Delete(int id){ }
    }
}
