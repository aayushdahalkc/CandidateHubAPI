using CandidateHubAPI.ApplicationCore.Entities;
using CandidateHubAPI.Interface.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CandidateHubAPI.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidateController : ControllerBase
    {
        private readonly ICandidateRepository _repository;

        public CandidateController(ICandidateRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public async Task<IActionResult> AddOrUpdateCandidate(Candidate candidate)
        {
            if (candidate == null || string.IsNullOrEmpty(candidate.Email))
                return BadRequest("Invalid candidate data.");

            try
            {
                var result = await _repository.AddOrUpdateAsync(candidate);
                return Ok(new
                {
                    message = result.Id > 0 ? "Candidate updated successfully." : "Candidate created successfully.",
                    candidateId = result.Id
                });
            }
            catch (Exception ex)
            {

                return StatusCode(500, "Internal Server Error"); ;
            }
           
        }
    }
}
