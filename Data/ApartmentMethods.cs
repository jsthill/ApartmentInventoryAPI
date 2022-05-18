using ApartmentInventoryAPI.Models;
using System.Collections.Generic;

namespace ApartmentInventoryAPI.Data
{
    /// <summary>
    /// API data access methods that are exposed.
    /// </summary>
    public class ApartmentMethods : IApartmentCommands
    {
        DbAccess dbAccess = new DbAccess();
        public ApartmentMethods()
        {

        }

        /// <summary>
        /// Method to query the database and return a specific apartment based on the code.
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public Apartment GetApartmentByCode(string code)
        {
            return dbAccess.GetApartmentByCode(code);
        }

        /// <summary>
        /// Method to return a specific apartment record based on id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Apartment GetApartmentById(int id)
        {
            return dbAccess.GetApartmentById(id);
        }

        /// <summary>
        /// Returns a list of all apartments in the table.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Apartment> GetApartmentList()
        {
            return dbAccess.GetApartmentList();
        }

        /// <summary>
        /// Returns a list of all apartments within a given block.
        /// </summary>
        /// <param name="block"></param>
        /// <returns></returns>
        public IEnumerable<Apartment> GetApartmentsByBlock(string block)
        {
            return dbAccess.GetApartmentsByBlock(block);
        }

        /// <summary>
        /// Returns a list of all available apartments.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Apartment> GetListOfAvailableApartments()
        {
            return dbAccess.GetAvailableApartments();
        }

        /// <summary>
        /// Add a new apartment to the table.
        /// </summary>
        /// <param name="apt"></param>
        public void AddNewApartment(Apartment apt)
        {
            dbAccess.AddNewApartment(apt);
        }

        /// <summary>
        /// Update an existing apartment record based on the unique id.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="apt"></param>
        public void UpdateApartment(int id, Apartment apt)
        {
            dbAccess.UpdateApartment(id, apt);
        }

        /// <summary>
        /// Delete an apartment record from the database.
        /// </summary>
        /// <param name="id"></param>
        public void DeleteApartment(int id)
        {
            dbAccess.DeleteApartment(id);
        }
    }
}