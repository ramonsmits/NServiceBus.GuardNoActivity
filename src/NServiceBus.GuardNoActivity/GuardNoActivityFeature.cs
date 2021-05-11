using System;
using NServiceBus;
using NServiceBus.Features;
using NServiceBus.Logging;

class GuardNoActivityFeature : Feature
{
    static readonly ILog Log = LogManager.GetLogger("NServiceBus.GuardNoActivity");

    public GuardNoActivityFeature()
    {
        EnableByDefault();
    }

    protected override void Setup(FeatureConfigurationContext context)
    {
        if (context.Settings.TryGet("NoActivityDuration", out TimeSpan noActivityDuration))
        {
            context.Pipeline.Register<GuardNoActivityBehavior>(x => new GuardNoActivityBehavior(x.Build<CriticalError>(), noActivityDuration), nameof(GuardNoActivityBehavior));
        }
    }
}