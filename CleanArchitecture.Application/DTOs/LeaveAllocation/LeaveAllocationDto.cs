using CleanArchitecture.Application.DTOs.Common;
using CleanArchitecture.Application.DTOs.LeaveType;
using CleanArchitecture.Application.Models.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Application.DTOs.LeaveAllocation
{
    public class LeaveAllocationDto : BaseDto
    {
        public int NumberOfDays { get; set; }
        public LeaveTypeDto LeaveType { get; set; }
        public Employee Employee { get; set; }
        public string EmployeeId { get; set; }
        public int LeaveTypeId { get; set; }
        public int Period { get; set; }
    }
}
