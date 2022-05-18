using ApartmentInventoryAPI.Models;
using System.Collections.Generic;

namespace ApartmentInventoryAPI.Data
{
    /// <summary>
    /// API repository for Apartments.
    /// </summary>
    public interface IApartmentCommands
    {
        /// <summary>
        /// Get list of all apartments.
        /// </summary>
        /// <returns></returns>
        IEnumerable<Apartment> GetApartmentList();
        Apartment GetApartmentById(int id);
        Apartment GetApartmentByCode(string code);
        IEnumerable<Apartment> GetApartmentsByBlock(string block);
        IEnumerable<Apartment> GetListOfAvailableApartments();
        void AddNewApartment(Apartment apt);
        void UpdateApartment(int id, Apartment apt);
        void DeleteApartment(int id);
    }
}
