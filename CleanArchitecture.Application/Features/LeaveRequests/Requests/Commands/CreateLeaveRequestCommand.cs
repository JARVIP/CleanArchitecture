using CleanArchitecture.Application.DTOs.LeaveRequest;
using CleanArchitecture.Application.DTOs.LeaveType;
using CleanArchitecture.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Application.Features.LeaveRequests.Requests.Commands
{
    public class CreateLeaveRequestCommand : IRequest<BaseCommandResponse>
    {
        public CreateLeaveRequestDto LeaveRequestDto { get; set; }

    }
}
