﻿using AutoMapper;
using CleanArchitecture.Application.DTOs.LeaveAllocation.Validators;
using CleanArchitecture.Application.Exceptions;
using CleanArchitecture.Application.Features.LeaveAllocations.Requests.Commands;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Features.LeaveAllocations.Handlers.Commands
{
    public class CreateLeaveAllocationCommandHandler : IRequestHandler<CreateLeaveAllocationCommand, int>
    {
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;

        public CreateLeaveAllocationCommandHandler(ILeaveAllocationRepository leaveAllocationRepository, ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
        {
            _leaveAllocationRepository = leaveAllocationRepository;
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateLeaveAllocationCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateLeaveAllocationDtoValidator(_leaveTypeRepository);

            var validationResult = await validator.ValidateAsync(request.LeaveAllocationDto);

            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult);
            }

            var leaveAllocation = _mapper.Map<LeaveAllocation>(request.LeaveAllocationDto);

            leaveAllocation = await _leaveAllocationRepository.Add(leaveAllocation);

            return leaveAllocation.Id;
        }
    }
}
