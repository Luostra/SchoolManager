using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SchoolManagerBackend.Models
{
    public class StudentClass
    {
        [ForeignKey("Student")]
        public int StudentId { get; set; }

        [ForeignKey("Class")]
        public int ClassId { get; set; }

        [Required]
        [MaxLength(10)]
        public string AcademicYear { get; set; }

        // Навигационные свойства
        public Student Student { get; set; }
        public Class Class { get; set; }
    }
}
