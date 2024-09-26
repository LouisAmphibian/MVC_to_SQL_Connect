using System.ComponentModel.DataAnnotations;

namespace CourseManager.Models
{
    public class Course
    {
            public int Id { get; set; }

            [MaxLength(100)]
            public string Name { get; set; } = "";

            [MaxLength(100)]
            public string ModuleName { get; set; } = "";
            public string Description { get; set; } = "";
        
    }
}
