namespace Finance.Domain.Core
{
    using System;

    public interface IEvent
    {
        DateTime DateOcurred { get; }
    }
}