# Changelog

## [4.0.0] - 2026-02-15

Upgrades to NServiceBus 10.x and .NET 10.0. The feature remains auto-enabled via assembly scanning for backward compatibility, but you should explicitly call `RaiseCriticalWhenNoActivity()` to prepare for NServiceBus 11. The critical error message now shows elapsed time vs configured limit, making misconfiguration easier to spot.

### Breaking changes

- Support NServiceBus 10.x, target net10.0 (c293700)

### Migration

- Explicitly call `RaiseCriticalWhenNoActivity()` on `EndpointConfiguration` — NServiceBus 11 will remove assembly scanning of features and `EnableByDefault()` will stop working

### Improvements

- Improve critical error message: show actual elapsed time, configured limit, and UTC-formatted timestamp (01b3055)

### Internal

- Replace magic string settings key with `GuardNoActivityOptions` configuration object (1913d39)
- Code cleanup: file-scoped namespaces, modern argument validation, remove unused code (98ae30a)
- Remove redundant `Microsoft.SourceLink.GitHub` (built into .NET 8+ SDK) (554b390)
- Switch to MinVer for tag-based versioning (5a3bd00)
- Add justfile for build, pack, and publish workflows (9d65282)
- Add GitHub Actions CI workflow (e31ef97)
- Switch to NuGet Trusted Publishing (1403914)

### Dependencies

- NServiceBus [10.0.0, 11.0.0)
- MinVer 7.0.0

## [3.0.0] - 2024-06-14

Target: NServiceBus 9.x | .NET 8.0

- Support NServiceBus 9.x
- Improved demo

### Dependencies

- Microsoft.SourceLink.GitHub 8.0.0

## [2.0.0] - 2022-12-09

Target: NServiceBus 8.x

- Support NServiceBus 8.x
- Add demo project

## [1.0.0] - 2021-05-11

- Initial release

[4.0.0]: https://github.com/ramonsmits/NServiceBus.GuardNoActivity/compare/3.0.0...4.0.0
[3.0.0]: https://github.com/ramonsmits/NServiceBus.GuardNoActivity/compare/2.0.0...3.0.0
[2.0.0]: https://github.com/ramonsmits/NServiceBus.GuardNoActivity/compare/1.0.0...2.0.0
[1.0.0]: https://github.com/ramonsmits/NServiceBus.GuardNoActivity/releases/tag/1.0.0
