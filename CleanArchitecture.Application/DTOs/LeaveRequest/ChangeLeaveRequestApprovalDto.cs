using CleanArchitecture.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Application.DTOs.LeaveRequest
{
    public class ChangeLeaveRequestApprovalDto : BaseDto
    {
        public bool Approved { get; set; }
    }
}
