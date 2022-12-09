using NServiceBus;

var cfg = new EndpointConfiguration("demo");
cfg.UseTransport(new LearningTransport());
cfg.EnableInstallers();
cfg.RaiseCriticalWhenNoActivity(TimeSpan.FromSeconds(3));
cfg.Recoverability().Immediate(c => c.NumberOfRetries(0));
cfg.Recoverability().Delayed(c => c.NumberOfRetries(0));

var instance = await Endpoint.Start(cfg);
await Task.Delay(TimeSpan.FromSeconds(10));

await instance.Stop();

class MyMessage : IMessage
{
}