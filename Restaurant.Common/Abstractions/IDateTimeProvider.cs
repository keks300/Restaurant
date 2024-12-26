using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Common.Abstractions
{
    public interface IDateTimeProvider
    {
        DateTimeOffset Now { get; }

        DateTimeOffset UtcNow { get; }
    }
}
