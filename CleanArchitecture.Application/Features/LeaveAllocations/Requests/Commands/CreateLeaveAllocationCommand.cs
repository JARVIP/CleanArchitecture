using CleanArchitecture.Application.DTOs.LeaveAllocation;
using CleanArchitecture.Application.DTOs.LeaveType;
using CleanArchitecture.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Application.Features.LeaveAllocations.Requests.Commands
{
    public class CreateLeaveAllocationCommand : IRequest<BaseCommandResponse>
    {
        public CreateLeaveAllocationDto LeaveAllocationDto { get; set; }
    }
}
