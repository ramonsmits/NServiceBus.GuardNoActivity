using System;
using Microsoft.Extensions.DependencyInjection;
using NServiceBus;
using NServiceBus.Features;
using NServiceBus.Logging;

class GuardNoActivityFeature : Feature
{
    static readonly ILog Log = LogManager.GetLogger("NServiceBus.GuardNoActivity");

    protected override void Setup(FeatureConfigurationContext context)
    {
        if (context.Settings.TryGet("NoActivityDuration", out TimeSpan noActivityDuration))
        {
            context.Pipeline.Register<GuardNoActivityBehavior>(x => new GuardNoActivityBehavior(x.GetRequiredService<CriticalError>(), noActivityDuration), nameof(GuardNoActivityBehavior));
        }
    }
}