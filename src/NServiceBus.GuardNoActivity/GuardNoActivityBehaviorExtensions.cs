using System;
using NServiceBus.Configuration.AdvancedExtensibility;

namespace NServiceBus
{
    /// <summary>
    /// Configuration class for durable messaging.
    /// </summary>
    public static class GuardNoActivityBehaviorExtensions
    {
        /// <summary>
        /// Instructs the transport to limits the allowed concurrency when processing messages.
        /// </summary>
        /// <param name="config">The <see cref="EndpointConfiguration" /> instance to apply the settings to.</param>
        /// <param name="noActivityDuration"></param>
        public static void RaiseCriticalWhenNoActivity(this EndpointConfiguration config, TimeSpan noActivityDuration)
        {
            if (config == null) throw new ArgumentNullException(nameof(config));
            if (noActivityDuration == default) throw new ArgumentNullException(nameof(noActivityDuration));
            if (noActivityDuration.Ticks<0) throw new ArgumentOutOfRangeException(nameof(noActivityDuration), noActivityDuration, "Must be positive");
            config.GetSettings().Set("NoActivityDuration", noActivityDuration);
        }
    }
}