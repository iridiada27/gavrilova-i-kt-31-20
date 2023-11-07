using Prpr.Models;
using Xunit;

namespace Prpr.Tests
{
    public class SubjectTests
    {
        [Fact]
        public void IsValidSubjectName_Prpr_True()
        {
            var testSubject = new Subject()
            {
                SubjectName = "Prpr"
            };

            var result = testSubject.IsValidSubjectName();

            Assert.True(result);

        }
    }
}