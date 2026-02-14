using System;
using Microsoft.Extensions.DependencyInjection;
using NServiceBus;
using NServiceBus.Features;

class GuardNoActivityFeature : Feature
{
    protected override void Setup(FeatureConfigurationContext context)
    {
        if (context.Settings.TryGet("NoActivityDuration", out TimeSpan noActivityDuration))
        {
            context.Pipeline.Register<GuardNoActivityBehavior>(x => new GuardNoActivityBehavior(x.GetRequiredService<CriticalError>(), noActivityDuration), nameof(GuardNoActivityBehavior));
        }
    }
}
