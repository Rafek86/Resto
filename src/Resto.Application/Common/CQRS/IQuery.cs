using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resto.Application.Common.CQRS
{
    public interface IQuery<out TRespose> :IRequest<TRespose>
        where TRespose : notnull
    {
    }
}
