# NServiceBus.GuardNoActivity

Raises NServiceBus critical error after a configurable duration of inactivity.

## Version compatibility

| NServiceBus | NServiceBus.GuardNoActivity |
| ----------- | --------------------------- |
| v7.x        | v1.x                        |

## Introduction

Message processing can come a a halt for sometimes very hard to detect reasons. Some systems always have a flow of messages. If no message is processed for a while that could be very suspicious. Maybe there are plenty of message but the processing deadlocked itself.

This package ensures that if no message is received within the configured period that the endpoint will raise a critical error. Most implementations should terminate the endpoint instance or endpoint instance process so that the process host can restart and revive message processing.

## Configuration

Raise a critical error after 5 minutes:

```c#
endpointConfiguration.RaiseCriticalWhenNoActivity(TimeSpan.FromMinutes(5));
```
