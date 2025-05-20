using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace SchoolManagerBackend.Models
{
    public class User : IdentityUser<int>
    {

        [Required]
        public UserRole Role { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Навигационные свойства
        public Teacher? Teacher { get; set; }
        public Student? Student { get; set; }
    }

    public enum UserRole
    {
        Student,
        Teacher,
        HeadTeacher
    }
}
