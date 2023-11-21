using Prpr.Models;
using Xunit;

namespace Prpr.Tests
{
    public class GroupTests
    {
        [Fact]
        public void IsValidGroupName_KT3120_True()
        {
            var testGroup = new Group
            {
                GroupName = "ÊÒ-31-20"
                
            };

            var result = testGroup.IsValidGroupName();

            Assert.True(result);
        }
    }
}