using AutoMapper;
using CleanArchitecture.Application.DTOs.LeaveType.Validators;
using CleanArchitecture.Application.Exceptions;
using CleanArchitecture.Application.Features.LeaveTypes.Requests.Commands;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Features.LeaveTypes.Handlers.Commands
{
    public class UpdateLeaveTypeCommandHandler : IRequestHandler<UpdateLeaveTypeCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateLeaveTypeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateLeaveTypeDtoValidator();
            var validationResult = await validator.ValidateAsync(request.LeaveTypeDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var leaveType = await _unitOfWork.LeaveTypeRepository.Get(request.LeaveTypeDto.Id);

            if (leaveType is null)
                throw new NotFoundException(nameof(leaveType), request.LeaveTypeDto.Id);

            _mapper.Map(request.LeaveTypeDto, leaveType);

            await _unitOfWork.LeaveTypeRepository.Update(leaveType);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
