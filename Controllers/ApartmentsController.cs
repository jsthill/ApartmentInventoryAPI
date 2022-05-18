using ApartmentInventoryAPI.Data;
using ApartmentInventoryAPI.Models;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace ApartmentInventoryAPI.Controllers
{
    [Authorize]
    /// <summary>
    /// Apartment controller class. This is where you'll find all the endpoints for the apartment api.
    /// </summary>
    public class ApartmentsController : ApiController
    {
        private IApartmentCommands _apartmentRepos;
        /// <summary>
        /// Constructor uising code injection from IApartmentCommands.
        /// </summary>
        /// <param name="apartmentRepos"></param>
        public ApartmentsController(IApartmentCommands apartmentRepos)
        {
            _apartmentRepos = apartmentRepos;
        }

        /// <summary>
        /// Returns a list of all apartments.
        /// </summary>
        /// <returns></returns>
        // GET: api/Apartments
        public IEnumerable<Apartment> Get()
        {
            return _apartmentRepos.GetApartmentList();
        }

        /// <summary>
        /// Gets an apartment by the unique id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Apartment record.</returns>
        // GET: api/Apartments/5
        public Apartment Get(int id)
        {
            return _apartmentRepos.GetApartmentById(id);
        }

        /// <summary>
        /// Get a single apartment by unique code.
        /// </summary>
        /// <param name="code"></param>
        /// <returns>Apartment record.</returns>
        // GET: api/Apartments/code/{code}
        [Route("api/apartments/code/{code}")]
        [HttpGet]
        public Apartment GetApartmentByCode(string code)
        {
            return _apartmentRepos.GetApartmentByCode(code);
        }

        /// <summary>
        /// Returns a list of apartments with the same block code.
        /// Path: api/Apartments/block/{block}
        /// </summary>
        /// <param name="block"></param>
        /// <returns></returns>
        // GET: api/Apartments/block/{block}
        [Route("api/apartments/block/{block}")]
        [HttpGet]
        public IEnumerable<Apartment> GetApartmentsByBlock(string block)
        {
            return _apartmentRepos.GetApartmentsByBlock(block);
        }

        /// <summary>
        /// Returns a list of available apartments.
        /// Path: api/Apartments/available
        /// </summary>
        /// <returns></returns>
        // GET: api/Apartments/available
        [Route("api/apartments/available")]
        [HttpGet]
        public IEnumerable<Apartment> GetAvailableApartments()
        {
            return _apartmentRepos.GetListOfAvailableApartments();
        }

        /// <summary>
        /// Adds a new apartment record to the table.
        /// </summary>
        /// <param name="apt"></param>
        /// <returns></returns>
        // POST: api/Apartments
        public IHttpActionResult Post([FromBody] Apartment apt)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                _apartmentRepos.AddNewApartment(apt);
                return Ok("Record successfully added.");
            }
            catch (Exception e)
            {
                return Ok(e.Message);
            }
        }

        /// <summary>
        /// Updates an apartment record by unique id.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="apt"></param>
        /// <returns></returns>
        // PUT: api/Apartments/5
        public IHttpActionResult Put(int id, [FromBody] Apartment apt)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                _apartmentRepos.UpdateApartment(id, apt);
                return Ok("Record successfully updated.");
            }
            catch (Exception e)
            {
                return Ok(e.Message);
            }
        }

        /// <summary>
        /// Deletes a specific apartment record by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // DELETE: api/Apartments/5
        public IHttpActionResult Delete(int id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                _apartmentRepos.DeleteApartment(id);
                return Ok("Record successfully deleted.");
            }
            catch (Exception e)
            {
                return Ok(e.Message);
            }
        }
    }
}
