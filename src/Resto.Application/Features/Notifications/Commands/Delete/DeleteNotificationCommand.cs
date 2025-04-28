using Resto.Application.Common.CQRS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resto.Application.Features.Notifications.Commands.Delete
{
    public record DeleteNotificationCommand(string Id):ICommand<DeleteNotificationResult>;

    //TODO : Make the Delete Rule in the EfCore Configuration NoAction
    public record DeleteNotificationResult(bool isSuccess);
}
