using AutoMapper;
using CleanArchitecture.Application.DTOs.LeaveAllocation.Validators;
using CleanArchitecture.Application.Exceptions;
using CleanArchitecture.Application.Features.LeaveAllocations.Requests.Commands;
using CleanArchitecture.Application.Features.LeaveTypes.Requests.Commands;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Features.LeaveAllocations.Handlers.Commands
{
    public class UpdateLeaveAllocationCommandHandler : IRequestHandler<UpdateLeaveAllocationCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateLeaveAllocationCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateLeaveAllocationCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateLeaveAllocationDtoValidator(_unitOfWork.LeaveTypeRepository);
            var validationResult = await validator.ValidateAsync(request.LeaveAllocationDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var leaveAllocation = await _unitOfWork.LeaveAllocationRepository.Get(request.LeaveAllocationDto.Id);

            if (leaveAllocation is null)
                throw new NotFoundException(nameof(leaveAllocation), request.LeaveAllocationDto.Id);

            _mapper.Map(request.LeaveAllocationDto, leaveAllocation);

            await _unitOfWork.LeaveAllocationRepository.Update(leaveAllocation);
            await _unitOfWork.Save();
            return Unit.Value;
        }
    }
}
