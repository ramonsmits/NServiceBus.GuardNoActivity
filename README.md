# NServiceBus.GuardNoActivity

Raises NServiceBus critical error after a configurable duration of inactivity.

## Version compatibility

| NServiceBus | NServiceBus.GuardNoActivity |
| ----------- | --------------------------- |
| v10.x       | v4.x                        |
| v9.x        | v3.x                        |
| v8.x        | v2.x                        |
| v7.x        | v1.x                        |

## Introduction

Message processing can come to a halt for sometimes very hard to detect reasons. Some systems always have a flow of messages. If no message is processed for a while that could be very suspicious and in a lot of systems simply not possible. Maybe there are plenty of message but the processing deadlocked itself.

This package ensures that if no message is received within the configured period that the endpoint will [raise an NServiceBus critical error](https://docs.particular.net/nservicebus/hosting/critical-errors). Most implementations should terminate the endpoint instance or endpoint instance process so that the process host can restart and revive message processing.

## Installation

Install the Nuget package [NServiceBus.GuardNoActivity](https://www.nuget.org/packages/NServiceBus.GuardNoActivity)

```txt
Install-Package NServiceBus.GuardNoActivity
```

## Configuration

Raise a critical error after 5 minutes:

```c#
endpointConfiguration.RaiseCriticalWhenNoActivity(TimeSpan.FromMinutes(5));
```

## Demo

Included is a demo project. It uses a 3 second activity window. After starting it waits 10 seconds and you'll get 3 log entries indicating there was no activity.

Output:

```txt
2026-02-15 12:40:03.166 INFO  Logging to '…/NServiceBus.GuardNoActivityDemo/bin/Release/net10.0/' with level Info
Received message at 02/15/2026 12:40:03
Received message at 02/15/2026 12:40:05
Received message at 02/15/2026 12:40:07
2026-02-15 12:40:10.405 FATAL No activity for 00:00:03 (limit: 00:00:03), last activity 2026-02-15 12:40:07Z
System.Exception: No activity for 00:00:03 (limit: 00:00:03), last activity 2026-02-15 12:40:07Z
2026-02-15 12:40:13.407 FATAL No activity for 00:00:06 (limit: 00:00:03), last activity 2026-02-15 12:40:07Z
System.Exception: No activity for 00:00:06 (limit: 00:00:03), last activity 2026-02-15 12:40:07Z
2026-02-15 12:40:16.408 FATAL No activity for 00:00:09 (limit: 00:00:03), last activity 2026-02-15 12:40:07Z
System.Exception: No activity for 00:00:09 (limit: 00:00:03), last activity 2026-02-15 12:40:07Z
2026-02-15 12:40:19.402 INFO  Initiating shutdown.
2026-02-15 12:40:19.410 INFO  Shutdown complete.
```