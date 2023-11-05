using System.Text.RegularExpressions;

namespace Prpr.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Otchestvo { get; set; }
        public int GroupId { get; set; }
        public Group Group { get; set; }
    }
}
