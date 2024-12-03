using CandidateHubAPI.ApplicationCore.Entities;
using CandidateHubAPI.Interface.Repositories;
using CandidateHubAPI.Web.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateHubAPI.Tests.ControllerTests
{
    public class CandidateControllerTests
    {
        private readonly Mock<ICandidateRepository> _candidateRepositoryMock;
        private readonly CandidateController _controller;
        public CandidateControllerTests() { 
            _candidateRepositoryMock = new Mock<ICandidateRepository>();
            _controller = new CandidateController(_candidateRepositoryMock.Object);
        }

        [Fact]
        public async Task AddOrUpdateCandidate_ReturnsOkResult_WhenValidCandidateIsProvided()
        {
            // Arrange
            var candidate = new Candidate
            {
                FirstName = "Ram",
                LastName = "Hari",
                Email = "ram.hari@test.com",
                Comments = "test candidate"
            };

            // Mock setup: returns the same candidate that is passed
            _candidateRepositoryMock.Setup(r => r.AddOrUpdateAsync(It.IsAny<Candidate>()))
                .ReturnsAsync((Candidate candidate) => candidate);

            // Act
            var result = await _controller.AddOrUpdateCandidate(candidate);

            // Assert
            Assert.IsType<OkObjectResult>(result);
            _candidateRepositoryMock.Verify(r => r.AddOrUpdateAsync(It.IsAny<Candidate>()), Times.Once);
        }

    }
}
