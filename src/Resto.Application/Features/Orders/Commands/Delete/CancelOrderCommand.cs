using Resto.Application.Common.CQRS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resto.Application.Features.Orders.Commands.Delete
{
    public record CancelOrderCommand(
        string OrderId
    ) : ICommand<CancelOrderResult>;

    public record CancelOrderResult(
        bool isSuccess
    );
}
