using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Security.Claims;

namespace SchoolManagerBackend.Models
{
    public class Teacher
    {
        [Key]
        public int TeacherId { get; set; }

        [Required]
        [ForeignKey("User")]
        public int UserId { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [MaxLength(50)]
        public string? MiddleName { get; set; }

        [MaxLength(20)]
        public string? Phone { get; set; }


        // Навигационные свойства
        public User User { get; set; }
        public ICollection<TeacherSubject> TeacherSubjects { get; set; }
        public ICollection<Class> ClassesLed { get; set; }
        public ICollection<Grade> GradesGiven { get; set; }
    }
}
