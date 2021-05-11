using System;
using System.Threading;
using System.Threading.Tasks;
using NServiceBus;
using NServiceBus.Pipeline;

class GuardNoActivityBehavior : IBehavior<IIncomingPhysicalMessageContext, IIncomingPhysicalMessageContext>
{
    readonly CriticalError CriticalError;
    readonly TimeSpan NoActivityDuration;
    readonly Timer InactivityTimer;
    DateTime last;

    public GuardNoActivityBehavior(CriticalError criticalError, TimeSpan noActivityDuration)
    {
        NoActivityDuration = noActivityDuration;
        CriticalError = criticalError;
        InactivityTimer = new Timer(s => HandleTimerCallback());
        last = DateTime.UtcNow;
        HandleTimerCallback();
    }

    void HandleTimerCallback()
    {
        var age = DateTime.UtcNow - last;
        var remaining = NoActivityDuration - age;

        if (remaining.Ticks < 0)
        {
            var ex = new Exception($"No activity for {NoActivityDuration}, last activity {last}");
            CriticalError.Raise(ex.Message, ex);
            remaining = NoActivityDuration;
        }

        InactivityTimer.Change(remaining, Timeout.InfiniteTimeSpan);
    }

    public Task Invoke(IIncomingPhysicalMessageContext context, Func<IIncomingPhysicalMessageContext, Task> next)
    {
        last = DateTime.UtcNow;
        return next(context);
    }
}