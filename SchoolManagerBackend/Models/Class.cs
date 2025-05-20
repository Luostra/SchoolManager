using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SchoolManagerBackend.Models
{
    public class Class
    {
        [Key]
        public int ClassId { get; set; }

        [Required]
        [MaxLength(20)]
        public string ClassName { get; set; } // Например "10A", "11B"

        [ForeignKey("ClassLeader")]
        public int? ClassLeaderId { get; set; } // Классный руководитель

        [Required]
        [MaxLength(10)]
        public string AcademicYear { get; set; } // Например "2023-2024"

        // Навигационные свойства
        public Teacher? ClassLeader { get; set; }
        public ICollection<StudentClass> StudentClasses { get; set; }
    }
}
