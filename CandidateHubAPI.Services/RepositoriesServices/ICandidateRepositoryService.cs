using CandidateHubAPI.ApplicationCore.Entities;
using CandidateHubAPI.Infrastructure;
using CandidateHubAPI.Interface.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CandidateHubAPI.Services.RepositoriesServices
{
    public class ICandidateRepositoryService : ICandidateRepository
    {
        private readonly CandidateDbContext _context;
        public ICandidateRepositoryService(CandidateDbContext context)
        {
            _context = context;
        }
        public async Task<Candidate> GetByEmailAsync(string email)
        {
            return await _context.Candidate.FirstOrDefaultAsync(c => c.Email == email);
        }

        public async Task<Candidate> AddOrUpdateAsync(Candidate candidate)
        {
            var existingCandidate = await GetByEmailAsync(candidate.Email);

            if (existingCandidate != null)
            {
                existingCandidate.FirstName = candidate.FirstName;
                existingCandidate.LastName = candidate.LastName;
                existingCandidate.PhoneNumber = candidate.PhoneNumber;
                existingCandidate.CallTimeInterval = candidate.CallTimeInterval;
                existingCandidate.LinkedInUrl = candidate.LinkedInUrl;
                existingCandidate.GitHubUrl = candidate.GitHubUrl;
                existingCandidate.Comments = candidate.Comments;
                existingCandidate.UpdatedAt = DateTime.UtcNow;

                _context.Candidate.Update(existingCandidate);
            }
            else
            {
                _context.Candidate.Add(candidate);
            }

            await _context.SaveChangesAsync();
            return candidate;
        }
    }
}
