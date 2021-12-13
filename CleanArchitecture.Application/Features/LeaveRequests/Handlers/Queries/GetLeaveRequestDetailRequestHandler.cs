using AutoMapper;
using CleanArchitecture.Application.DTOs;
using CleanArchitecture.Application.DTOs.LeaveRequest;
using CleanArchitecture.Application.Features.LeaveRequests.Requests.Queries;
using CleanArchitecture.Application.Features.LeaveTypes.Requests;
using CleanArchitecture.Application.Features.LeaveTypes.Requests.Queries;
using CleanArchitecture.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CleanArchitecture.Application.Contracts.Identity;

namespace CleanArchitecture.Application.Features.LeaveRequests.Handlers.Queries
{
    public class GetLeaveRequestDetailRequestHandler : IRequestHandler<GetLeaveRequestDetailRequest, LeaveRequestDto>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;

        public GetLeaveRequestDetailRequestHandler(ILeaveRequestRepository leaveRequestRepository,
            IMapper mapper,
            IUserService userService)
        {
            _leaveRequestRepository = leaveRequestRepository;
            _mapper = mapper;
            this._userService = userService;
        }
        public async Task<LeaveRequestDto> Handle(GetLeaveRequestDetailRequest request, CancellationToken cancellationToken)
        {
            var leaveRequest = _mapper.Map<LeaveRequestDto>(await _leaveRequestRepository.GetLeaveRequestWithDetails(request.Id));
            leaveRequest.Employee = await _userService.GetEmployee(leaveRequest.RequestingEmployeeId);
            return leaveRequest;
        }
    }
}
