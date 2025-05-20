using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SchoolManagerBackend.Models
{
    public class Grade
    {
        [Key]
        public int GradeId { get; set; }

        [Required]
        [ForeignKey("Student")]
        public int StudentId { get; set; }

        [Required]
        [ForeignKey("Subject")]
        public int SubjectId { get; set; }

        [Required]
        [ForeignKey("Teacher")]
        public int TeacherId { get; set; }

        [Required]
        [Range(1, 5)]
        public int GradeValue { get; set; } // Или другая шкала оценок

        [Required]
        public DateTime GradeDate { get; set; }

        [Required]
        public GradePeriod Period { get; set; }

        [Required]
        [MaxLength(10)]
        public string AcademicYear { get; set; }

        public string? Comment { get; set; }

        // Навигационные свойства
        public Student Student { get; set; }
        public Subject Subject { get; set; }
        public Teacher Teacher { get; set; }
    }

    public enum GradePeriod
    {
        Semester1,
        Semester2,
        Year
    }
}
