using CandidateHubAPI.ApplicationCore.Entities;
using CandidateHubAPI.Interface.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CandidateHubAPI.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidateController : ControllerBase
    {
        private readonly ICandidateRepository _repository;
        private readonly ILogger<CandidateController> _logger;

        public CandidateController(ILogger<CandidateController> logger, ICandidateRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpPost]
        public async Task<IActionResult> AddOrUpdateCandidate(Candidate candidate)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _repository.AddOrUpdateAsync(candidate);
            return Ok(new
            {
                message = result.Id > 0 ? "Candidate updated successfully." : "Candidate created successfully.",
                candidateId = result.Id
            });
        }
    }
}
