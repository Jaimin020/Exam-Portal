using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityExaminationMVC.Models
{
    public class PaperScore
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int Marks { get; set; }
        [Required]
        public int Student_Id { get; set; }
        [Required]
        public int Paper_Id { get; set; }
    }
}