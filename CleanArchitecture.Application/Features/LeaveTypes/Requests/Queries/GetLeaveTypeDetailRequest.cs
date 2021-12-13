using CleanArchitecture.Application.DTOs;
using CleanArchitecture.Application.DTOs.LeaveType;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Application.Features.LeaveTypes.Requests.Queries
{
    public class GetLeaveTypeDetailRequest : IRequest<LeaveTypeDto>
    {
        public int Id { get; set; }
    }
}
