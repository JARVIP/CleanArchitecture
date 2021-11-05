using AutoMapper;
using CleanArchitecture.Application.DTOs.LeaveRequest.Validators;
using CleanArchitecture.Application.Exceptions;
using CleanArchitecture.Application.Features.LeaveRequests.Requests.Commands;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Application.Responses;
using CleanArchitecture.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CleanArchitecture.Application.Contracts.Infrastructure;
using CleanArchitecture.Application.Models;

namespace CleanArchitecture.Application.Features.LeaveRequests.Handlers.Commands
{
    public class CreateLeaveRequestCommandHandler : IRequestHandler<CreateLeaveRequestCommand, BaseCommandResponse>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IEmailSender _emailSender;
        private readonly IMapper _mapper;

        public CreateLeaveRequestCommandHandler(ILeaveRequestRepository leaveRequestRepository, ILeaveTypeRepository leaveTypeRepository, IEmailSender emailSender, IMapper mapper)
        {
            _leaveRequestRepository = leaveRequestRepository;
            _leaveTypeRepository = leaveTypeRepository;
            _emailSender = emailSender;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateLeaveRequestCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateLeaveRequestDtoValidator(_leaveTypeRepository);
            var validationResult = await validator.ValidateAsync(request.LeaveRequestDto);

            if (!validationResult.IsValid)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
                
            }

            var leaveRequest = _mapper.Map<LeaveRequest>(request.LeaveRequestDto);

            leaveRequest = await _leaveRequestRepository.Add(leaveRequest);

            response.Success = true;
            response.Message = "Creation Successful";
            response.Id = leaveRequest.Id;


            var email = new Email
            {
                To = "Empoyee@gmail.com",
                Body = $"Your leave request for {request.LeaveRequestDto.StartDate} to {request.LeaveRequestDto.EndDate} " +
                $"has been submitted successfully.",
                Subject = "Leave Request Submitted"
            };
            try
            {
                await _emailSender.SendEmail(email);
            }catch(Exception ex)
            {
                /// log 
            }

            return response;
        }
    }
}
