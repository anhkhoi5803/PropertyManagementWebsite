using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FinalPro.Models
{
    public class UserMetadata
    {
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "Data of birth")]
        public System.DateTime DOB { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
    }
    public class BuildingMetadata
    {
        public string Address { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        [Display(Name = "Postal Code")]

        public string PostalCode { get; set; }
        [Display(Name = "Building Name")]

        public string BuildingName { get; set; }
        [Display(Name = "Has laundry")]

        public bool HasLaundry { get; set; }
        [Display(Name = "Has Parking")]

        public bool HasParking { get; set; }
        [Display(Name = "Include Utilities")]

        public bool IncludeUtils { get; set; }
        [Display(Name = "Close to transit")]

        public bool CloseToTransit { get; set; }
        public string Description { get; set; }
        [Display(Name = "Property Manager")]
        public virtual User User { get; set; }
        [Display(Name = "Property Owner")]
        public virtual User User1 { get; set; }
    }
    public class MessageMetadata
    {
        [Display(Name = "Date time")]

        public System.DateTime DateTime { get; set; }
        [Display(Name = "Message")]

        public string Message1 { get; set; }
        [Display(Name = "Receiver")]

        public virtual User User { get; set; }
        [Display(Name = "Sender")]

        public virtual User User1 { get; set; }
    }
    public class AppointmentMetadata
    {

        [Display(Name = "Date time")]
        public System.DateTime DateTime { get; set; }

        public string Note { get; set; }
        [Display(Name = "Potential Tenant")]

        public virtual User User { get; set; }
        [Display(Name = "Property Manager")]

        public virtual User User1 { get; set; }
    }
    public class AppartmentMetadata
    {

        [Display(Name = "# of Bedrooms")]
        public int NumOfBedrooms { get; set; }
        [Display(Name = "# of Bathroom")]

        public int NumOfBathRooms { get; set; }
    }

}