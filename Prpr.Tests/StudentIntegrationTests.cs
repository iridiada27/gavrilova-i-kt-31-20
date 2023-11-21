using Prpr.Database;
using Prpr.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Prpr.Interfaces.StudentInterfaces.IStudentService;
using Prpr.Interfaces.StudentInterfaces;


namespace Prpr.Tests
{
    public class StudentIntegrationTests
    {
        public readonly DbContextOptions<Marks> _dbContextOptions;

        public StudentIntegrationTests()
        {

            _dbContextOptions = new DbContextOptionsBuilder<Marks>().UseInMemoryDatabase(databaseName: "prpr1").Options;
        }

        [Fact]
        public async Task GetStudentsByGroupAsync_KT3120_TwoObjects()
        {
            // Arrange
            var ctx = new Marks(_dbContextOptions);
            var studentService = new StudentService(ctx);
            var groups = new List<Group>
            {
                new Group
                {
                    GroupName = "КТ-31-20",
                    Year = 2020,
                },
                new Group
                {
                    GroupName = "КТ-41-20",
                    Year = 2020,
                }
            };
            await ctx.Set<Group>().AddRangeAsync(groups);

            var students = new List<Student>
            {
                new Student
                {
                    Name = "qwerty",
                    Surname = "asdf",
                    Otchestvo = "zxc",
                    GroupId = 1,
                },
                new Student
                {
                    Name = "qwerty2",
                    Surname = "asdf2",
                    Otchestvo = "zxc2",
                    GroupId = 2,
                },

            };
            await ctx.Set<Student>().AddRangeAsync(students);

            await ctx.SaveChangesAsync();

            // Act
            var filter = new Filters.StudentFilters.StudentGroupFilter
            {
                GroupName = "КТ-31-20"
            };
            var studentsResult = await studentService.GetStudentsByGroupAsync(filter, CancellationToken.None);

            // Assert
            Assert.Equal(1, studentsResult.Length);


        }
    }
}
