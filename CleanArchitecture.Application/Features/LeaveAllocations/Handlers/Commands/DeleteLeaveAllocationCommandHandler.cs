using AutoMapper;
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
    public class DeleteLeaveAllocationCommandHandler : IRequestHandler<DeleteLeaveAllocationCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteLeaveAllocationCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteLeaveAllocationCommand request, CancellationToken cancellationToken)
        {
            var leaveAllocation = await _unitOfWork.LeaveAllocationRepository.Get(request.Id);

            if (leaveAllocation == null)
                throw new NotFoundException(nameof(LeaveAllocation), request.Id);

            await _unitOfWork.LeaveAllocationRepository.Delete(leaveAllocation);
            await _unitOfWork.Save();
            return Unit.Value;
        }
    }
}
