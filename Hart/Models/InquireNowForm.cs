using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hart.Models
{
    public class InquireNowForm
    {
        [Key]
        public int InquireNowId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [EmailAddress]        
        public string Email { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [Display(Name = "Arrival Date")]
        public DateTime ArrivalDate  { get; set; }

        [NotMapped]        
        public List<SelectListItem> AdultsList { get; set; }

        [NotMapped]        
        public List<SelectListItem> TeensList { get; set; }

        [NotMapped]        
        public List<SelectListItem> ChildrenList { get; set; }

        //[Required(ErrorMessage = "{0} is required.")]
        public string Adults { get; set; }

        //[Required(ErrorMessage = "{0} is required.")]
        public string Teens { get; set; }

        //[Required(ErrorMessage = "{0} is required.")]
        public string Children { get; set; }

        [Required]
        public string Message { get; set; }        
    }
}
