using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace doanchithang_lab456_1711061719.Models
{
    public class Attendance
    {
        public Course Course { get; set; }

        [Key]
        [Column(Order = 1)]
        public int CourseId { get; set; }
        public ApplicationUser Attendee { get; set; }
        [Key]
        [Column(Order = 2)]
        public string AttendId { get; set; }
        public object AttendeeId { get; internal set; }
    }
}