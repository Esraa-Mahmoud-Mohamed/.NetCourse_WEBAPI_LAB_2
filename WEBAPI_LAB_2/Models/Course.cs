using System.ComponentModel.DataAnnotations;

namespace WEBAPI_LAB_2.Models
{
    public class Course
    {
        public int ID { get; set; }
        [StringLength(50)]
        public string? Crs_name { get; set; }
        [StringLength(150)]
        public string? Crs_description { get; set; }
        public int? Duration { get; set; }
    }
}
