using System.Text.RegularExpressions;

namespace Prpr.Models
{
    public class Subject
    {
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public bool IsValidSubjectName()
        {
            return Regex.Match(SubjectName, @"\b[A-Z]\w*\b").Success;
        }
    }
}
