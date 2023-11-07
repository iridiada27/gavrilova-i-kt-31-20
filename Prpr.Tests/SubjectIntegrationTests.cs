using Prpr.Database;
using Prpr.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Prpr.Interfaces.SubjectInterfaces.ISubjectService;
using Prpr.Interfaces.SubjectInterfaces;


namespace Prpr.Tests
{
    public class SubjectIntegrationTests
    {
        public readonly DbContextOptions<Marks> _dbContextOptions;

        public SubjectIntegrationTests()
        {

            _dbContextOptions = new DbContextOptionsBuilder<Marks>().UseInMemoryDatabase(databaseName: "prpr1").Options;
        }

        [Fact]
        public async Task GetSubjectsByGroupAsync_Prpr_TwoObjects()
        {
            // Arrange
            var ctx = new Marks(_dbContextOptions);
            var subjectService = new SubjectService(ctx);
            var subjects = new List<Subject>
            {
                new Subject
                {
                    SubjectName="Prpr"
    },
                new Subject
                {
                    SubjectName="Fritaty-tatu-taty"
                }
            };
            await ctx.Set<Subject>().AddRangeAsync(subjects);

            var students = new List<Student>
            {
                new Student
                {
                    Name = "qwerty",
                    Surname = "asdf",
                    Otchestvo = "zxc",
                    GroupId = 0,
                },
                new Student
                {
                    Name = "qwerty2",
                    Surname = "asdf2",
                    Otchestvo = "zxc2",
                    GroupId = 1,
                },
            };
            await ctx.Set<Student>().AddRangeAsync(students);

            var marks = new List<Otsenka>
            {
                new Otsenka
                {
                    Mark=5,
                    StudentId = 1,
                    SubjectId = 1,
                },
                new Otsenka
                {
                    Mark=4,
                    StudentId = 1,
                    SubjectId = 0,
                },
                new Otsenka
                {
                    Mark=3,
                    StudentId = 0,
                    SubjectId = 1,
                },
                new Otsenka
                {
                    Mark=4,
                    StudentId = 0,
                    SubjectId = 0,
                }
            };
            await ctx.Set<Otsenka>().AddRangeAsync(marks);

            await ctx.SaveChangesAsync();

            // Act
            var filter = new Filters.SubjectFilters.SubjectGroupFilter
            {
                SubjectId = 1
            };
            var subjectResult = await subjectService.GetSubjectByGroupAsync(filter, CancellationToken.None);

            // Assert
            Assert.Equal(0, subjectResult.Length);


        }
    }
}
