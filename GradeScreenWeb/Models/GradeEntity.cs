using System.ComponentModel.DataAnnotations;

namespace GradeScreenWeb.Models
{
    public class GradeEntity
    {

        [Key]
        public int gardeId{get; set;}
        public string code{get; set;}
        public string description{get; set;}
        public string active{get; set;}

        
        
    }
}