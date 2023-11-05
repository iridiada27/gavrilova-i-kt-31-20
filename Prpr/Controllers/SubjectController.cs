using Prpr.Filters.SubjectFilters;
using Prpr.Interfaces.SubjectInterfaces;
using Microsoft.AspNetCore.Mvc;
namespace Prpr.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SubjectController:ControllerBase
    {
        private readonly ILogger<SubjectController> _logger;
        private readonly ISubjectService _subjectService;

        public SubjectController(ILogger<SubjectController> logger, ISubjectService subjectService)
        {
            _logger = logger;
            _subjectService = subjectService;
        }
        [HttpPost(Name = "GetSubjectBuGroup")]
        public async Task<IActionResult> GetSubjectsByGroupAsync(SubjectGroupFilter filter, CancellationToken cancellationToken)
        {

            var subjects = await _subjectService.GetSubjectByGroupAsync(filter, cancellationToken);
            return Ok(subjects);
        }
    }
}
