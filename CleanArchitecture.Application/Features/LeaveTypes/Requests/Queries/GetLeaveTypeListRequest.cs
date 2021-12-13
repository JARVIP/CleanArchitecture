using CleanArchitecture.Application.DTOs;
using CleanArchitecture.Application.DTOs.LeaveType;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Application.Features.LeaveTypes.Requests.Queries
{
    public class GetLeaveTypeListRequest : IRequest<List<LeaveTypeDto>>
    {
    }
}
