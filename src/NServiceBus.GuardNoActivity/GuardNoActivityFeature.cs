using System;
using Microsoft.Extensions.DependencyInjection;
using NServiceBus;
using NServiceBus.Features;

class GuardNoActivityFeature : Feature
{
    public GuardNoActivityFeature()
    {
#pragma warning disable CS0618 // EnableByDefault will be removed in NServiceBus 12; use EnableFeature<GuardNoActivityFeature>() via RaiseCriticalWhenNoActivity() for v11+ readiness
        EnableByDefault();
#pragma warning restore CS0618
    }

    protected override void Setup(FeatureConfigurationContext context)
    {
        if (context.Settings.TryGet(out GuardNoActivityOptions options))
        {
            context.Pipeline.Register<GuardNoActivityBehavior>(x => new GuardNoActivityBehavior(x.GetRequiredService<CriticalError>(), options.NoActivityDuration), nameof(GuardNoActivityBehavior));
        }
    }
}
