using CleanArchitecture.Application.DTOs.Common;
using CleanArchitecture.Application.DTOs.LeaveType;
using CleanArchitecture.Application.Models.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Application.DTOs.LeaveRequest
{
    public class LeaveRequestListDto : BaseDto
    {
        public Employee Employee { get; set; }
        public string RequestingEmployeeId { get; set; }
        public LeaveTypeDto LeaveType { get; set; }
        public DateTime DateRequested { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool? Approved { get; set; }
    }
}
