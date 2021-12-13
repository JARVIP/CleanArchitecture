using FluentValidation;
using CleanArchitecture.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.DTOs.LeaveRequest.Validators
{
    public class CreateLeaveRequestDtoValidator : AbstractValidator<CreateLeaveRequestDto>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public CreateLeaveRequestDtoValidator(ILeaveTypeRepository leaveTypeRepository)
        {
            _leaveTypeRepository = leaveTypeRepository;
            Include(new ILeaveRequestDtoValidator(_leaveTypeRepository));
        }
    }
}
