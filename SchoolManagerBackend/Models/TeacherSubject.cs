using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagerBackend.Models
{
    public class TeacherSubject
    {
        [ForeignKey("Teacher")]
        public int TeacherId { get; set; }

        [ForeignKey("Subject")]
        public int SubjectId { get; set; }

        // Навигационные свойства
        public Teacher Teacher { get; set; }
        public Subject Subject { get; set; }
    }
}
