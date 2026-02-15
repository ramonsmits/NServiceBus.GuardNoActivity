# AGENTS.md

Guidance for AI coding agents working in this repository.

## Overview

NServiceBus pipeline behavior that raises a critical error when no messages are processed within a configurable duration. Detects silent processing failures (deadlocks, stalled consumers) so the process host can restart the endpoint.

## Build

```bash
just build                # dotnet build -c Release
just run                  # run demo (3-second inactivity window)
just pack                 # create NuGet package in artifacts/
just release [version]    # update CHANGELOG, create git tag
```

No test projects exist. The demo project (`src/NServiceBus.GuardNoActivityDemo`) serves as a manual integration test.

## Architecture

All source is in `src/NServiceBus.GuardNoActivity/`:

- **`GuardNoActivityBehaviorExtensions.cs`** — Public API: `EndpointConfiguration.RaiseCriticalWhenNoActivity(TimeSpan)`. Stores duration in settings, enables the feature.
- **`GuardNoActivityFeature.cs`** — NServiceBus `Feature`. Reads duration from settings, registers the behavior in the incoming physical message pipeline.
- **`GuardNoActivityBehavior.cs`** — Pipeline behavior (`IBehavior<IIncomingPhysicalMessageContext, …>`). Updates a timestamp on each message; a `Timer` raises `CriticalError` when elapsed time exceeds the configured duration.

## Conventions

- Strong-named assembly (`src/key.snk`)
- Public API in the `NServiceBus` namespace; internal types have no namespace
- Nullable reference types enabled
- MinVer for tag-based SemVer; major version tracks NServiceBus major version
