using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateHubAPI.ApplicationCore.Entities
{
    public class Candidate : BaseEntity
    {

        [Required, MaxLength(100)]
        public string FirstName { get; set; }

        [Required, MaxLength(100)]
        public string LastName { get; set; }

        [Phone]
        public string? PhoneNumber { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        public string? CallTimeInterval { get; set; }

        [Url]
        public string? LinkedInUrl { get; set; }

        [Url]
        public string? GitHubUrl { get; set; }

        [Required]
        public string Comments { get; set; }

    }
}
