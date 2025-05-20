using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace SchoolManagerBackend.Models
{
    public class Subject
    {
        [Key]
        public int SubjectId { get; set; }

        [Required]
        [MaxLength(100)]
        public string SubjectName { get; set; }

        public string? Description { get; set; }

        // Навигационные свойства
        public ICollection<TeacherSubject> TeacherSubjects { get; set; }
        public ICollection<Grade> Grades { get; set; }
    }
}
