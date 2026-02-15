using System;
using NServiceBus.Configuration.AdvancedExtensibility;

namespace NServiceBus;

/// <summary>
/// Configuration extensions for the GuardNoActivity feature.
/// </summary>
public static class GuardNoActivityBehaviorExtensions
{
    /// <summary>
    /// Raises a critical error when no messages are processed within the specified duration.
    /// </summary>
    /// <param name="config">The <see cref="EndpointConfiguration" /> instance to apply the settings to.</param>
    /// <param name="noActivityDuration">The maximum allowed duration of inactivity.</param>
    public static void RaiseCriticalWhenNoActivity(this EndpointConfiguration config, TimeSpan noActivityDuration)
    {
        ArgumentNullException.ThrowIfNull(config);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(noActivityDuration, TimeSpan.Zero);
        config.GetSettings().Set(new GuardNoActivityOptions { NoActivityDuration = noActivityDuration });
        config.EnableFeature<GuardNoActivityFeature>();
    }
}
