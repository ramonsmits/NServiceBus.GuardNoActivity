var cfg = new EndpointConfiguration("demo");
cfg.UseSerialization(new SystemJsonSerializer());
cfg.UseTransport(new LearningTransport());
cfg.EnableInstallers();
cfg.RaiseCriticalWhenNoActivity(TimeSpan.FromSeconds(3));
cfg.Recoverability().Immediate(c => c.NumberOfRetries(0));
cfg.Recoverability().Delayed(c => c.NumberOfRetries(0));

var instance = await Endpoint.Start(cfg);

for (int i = 0; i < 3; i++)
{
    await instance.SendLocal(new MyMessage());
    await Task.Delay(TimeSpan.FromSeconds(2));
}

await Task.Delay(TimeSpan.FromSeconds(10));

await instance.Stop();

class MyMessage : IMessage
{
}

class MyHandler : IHandleMessages<MyMessage>
{
    public Task Handle(MyMessage message, IMessageHandlerContext context)
    {
        return Console.Out.WriteLineAsync($"Received message at {DateTime.Now}");
    }
}