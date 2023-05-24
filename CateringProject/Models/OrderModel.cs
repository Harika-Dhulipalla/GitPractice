using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CateringProject.Models
{
    public class OrderModel
    {
        public int UserId { get; set; }
        [Required(ErrorMessage ="Required")]
        [Display(Name ="User Name")]
        public string UserName { get; set; }
        [DataType(DataType.Date)]
        [Display(Name ="Date&Time")]
        [Required(ErrorMessage = "Required")]
        public DateTime CreatedDate { get; set; }
        [Required(ErrorMessage = "Required")]
        [Display(Name ="Phone Number")]
        public string PhoneNo { get; set; }
        [Required(ErrorMessage = "Required")]
        [Display(Name ="Email ID")]
        public string EmailId { get; set; }
    }
}