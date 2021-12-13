using CleanArchitecture.Application.DTOs.LeaveAllocation;
using CleanArchitecture.Application.DTOs.LeaveType;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Application.Features.LeaveAllocations.Requests.Commands
{
    public class UpdateLeaveAllocationCommand : IRequest<Unit>
    {
        public UpdateLeaveAllocationDto LeaveAllocationDto { get; set; }
    }
}
