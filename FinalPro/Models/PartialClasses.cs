using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FinalPro.Models
{
    [MetadataType(typeof(UserMetadata))]
    public partial class User
    {
    }
    [MetadataType(typeof(BuildingMetadata))]
    public partial class Building
    {
    }
    [MetadataType(typeof(MessageMetadata))]
    public partial class Message
    {
    }
    [MetadataType(typeof(AppointmentMetadata))]
    public partial class Appointment
    {
    }
    [MetadataType(typeof(AppartmentMetadata))]
    public partial class Appartment
    {
    }
}