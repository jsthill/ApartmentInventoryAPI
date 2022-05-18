using System;

namespace ApartmentInventoryAPI.Models
{
    /// <summary>
    /// Table to store apartment information.
    /// </summary>
    public class Apartment
    {
        /// <summary>
        /// Unique identity column.
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// Unique apartment code.
        /// </summary>
        public string code { get; set; }
        /// <summary>
        /// Address of the apartment
        /// </summary>
        public string location { get; set; }
        /// <summary>
        /// The apartment number.
        /// </summary>
        public int apartment_number { get; set; }
        /// <summary>
        /// Thw block the apartment resides.
        /// </summary>
        public string block { get; set; }
        /// <summary>
        /// Flag for the availability of the apartment.
        /// </summary>
        public int isOccupied { get; set; }
        /// <summary>
        /// The date the lease will expire.
        /// </summary>
        public DateTime leaseExpiryDate { get; set; }
    }
}