using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Features.LeaveAllocations.Requests.Commands
{
    public class DeleteLeaveAllocatonCommand : IRequest
    {
        public int Id { get; set; }

    }
}
