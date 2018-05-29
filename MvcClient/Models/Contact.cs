using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace MvcClient.Models
{
    public class Contact
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "FirstName Is Required")]
        [StringLength(maximumLength: 30)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "LastName Is Required")]
        [StringLength(maximumLength: 30)]
        public string LastName { get; set; }


        [Required(ErrorMessage = "EmailAddress Is Required")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "PhoneNumber Is Required")]
        [DataType(DataType.PhoneNumber)]
        public long? PhoneNo { get; set; }

        public Nullable<bool> ContactStatus { get; set; }
    }
}