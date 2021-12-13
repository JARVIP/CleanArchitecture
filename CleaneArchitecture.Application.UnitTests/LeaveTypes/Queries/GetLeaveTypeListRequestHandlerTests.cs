using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Application.DTOs.LeaveType;
using CleanArchitecture.Application.Features.LeaveTypes.Handlers.Queries;
using CleanArchitecture.Application.Features.LeaveTypes.Requests.Queries;
using CleanArchitecture.Application.Profiles;
using CleanArchitecture.Application.UnitTests.Mocks;
using CleanArchitecture.Domain;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace CleanArchitecture.Application.UnitTests.LeaveTypes.Queries
{
    public class GetLeaveTypeListRequestHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<ILeaveTypeRepository> _mockRepo;
        public GetLeaveTypeListRequestHandlerTests()
        {
            _mockRepo = MockLeaveTypeRepository.GetLeaveTypeRepository();

            var mapperConfig = new MapperConfiguration(c => 
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
        }

        [Fact]
        public async Task GetLeaveTypeListTest()
        {
            var handler = new GetLeaveTypeListRequestHandler(_mockRepo.Object, _mapper);

            var result = await handler.Handle(new GetLeaveTypeListRequest(), CancellationToken.None);

            result.ShouldBeOfType<List<LeaveTypeDto>>();

            result.Count.ShouldBe(3);
        }
    }
}
