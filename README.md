# NServiceBus.GuardNoActivity

Raises NServiceBus critical error after a configurable duration of inactivity.

## Version compatibility

| NServiceBus | NServiceBus.GuardNoActivity |
| ----------- | --------------------------- |
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
2022-12-09 17:23:07.844 INFO  Logging to 'S:\NServiceBus.GuardNoActivity\src\NServiceBus.GuardNoActivityDemo\bin\Debug\net6.0\' with level Info
2022-12-09 17:23:07.933 INFO  Selected active license from C:\ProgramData\ParticularSoftware\license.xml
License Expiration: 2023-01-01
2022-12-09 17:23:11.024 FATAL No activity for 00:00:03, last activity 9-12-2022 16:23:08
System.Exception: No activity for 00:00:03, last activity 9-12-2022 16:23:08
2022-12-09 17:23:14.034 FATAL No activity for 00:00:03, last activity 9-12-2022 16:23:08
System.Exception: No activity for 00:00:03, last activity 9-12-2022 16:23:08
2022-12-09 17:23:17.048 FATAL No activity for 00:00:03, last activity 9-12-2022 16:23:08
System.Exception: No activity for 00:00:03, last activity 9-12-2022 16:23:08
2022-12-09 17:23:18.040 INFO  Initiating shutdown.
2022-12-09 17:23:18.045 INFO  Shutdown complete.
```