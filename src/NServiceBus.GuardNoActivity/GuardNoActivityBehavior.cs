using System;
using System.Threading;
using System.Threading.Tasks;
using NServiceBus;
using NServiceBus.Pipeline;

class GuardNoActivityBehavior : IBehavior<IIncomingPhysicalMessageContext, IIncomingPhysicalMessageContext>
{
    readonly CriticalError criticalError;
    readonly TimeSpan noActivityDuration;
    readonly Timer inactivityTimer;
    DateTime last;

    public GuardNoActivityBehavior(CriticalError criticalError, TimeSpan noActivityDuration)
    {
        this.noActivityDuration = noActivityDuration;
        this.criticalError = criticalError;
        inactivityTimer = new Timer(_ => HandleTimerCallback());
        last = DateTime.UtcNow;
        HandleTimerCallback();
    }

    void HandleTimerCallback()
    {
        var age = DateTime.UtcNow - last;
        var remaining = noActivityDuration - age;

        if (remaining.Ticks < 0)
        {
            var ex = new Exception($"No activity for {noActivityDuration}, last activity {last}");
            criticalError.Raise(ex.Message, ex);
            remaining = noActivityDuration;
        }

        inactivityTimer.Change(remaining, Timeout.InfiniteTimeSpan);
    }

    public Task Invoke(IIncomingPhysicalMessageContext context, Func<IIncomingPhysicalMessageContext, Task> next)
    {
        last = DateTime.UtcNow;
        return next(context);
    }
}
