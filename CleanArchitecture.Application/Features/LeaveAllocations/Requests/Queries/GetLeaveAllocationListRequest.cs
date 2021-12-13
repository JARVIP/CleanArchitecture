using CleanArchitecture.Application.DTOs;
using CleanArchitecture.Application.DTOs.LeaveAllocation;
using CleanArchitecture.Application.DTOs.LeaveRequest;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Application.Features.LeaveAllocations.Requests.Queries
{
    public class GetLeaveAllocationListRequest : IRequest<List<LeaveAllocationDto>>
    {
        public bool IsLoggedInUser { get; set; }
    }
}
