using CandidateHubAPI.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateHubAPI.Interface.Repositories
{
    public interface ICandidateRepository
    {
        Task<Candidate> GetByEmailAsync(string email);
        Task<Candidate> AddOrUpdateAsync(Candidate candidate);
    }
}
