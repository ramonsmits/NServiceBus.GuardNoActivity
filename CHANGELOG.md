# Changelog

## [Unreleased]

Target: NServiceBus 10.x | .NET 10.0

- Support NServiceBus 10.x
- Target net10.0
- Remove `EnableByDefault()`, require explicit `EnableFeature` via configuration API
- Code cleanup: file-scoped namespaces, modern argument validation, remove unused code
- Remove redundant `Microsoft.SourceLink.GitHub` (built into .NET 8+ SDK)
- Switch to MinVer for tag-based versioning
- Add justfile for build, pack, and publish workflows
- Add GitHub Actions CI workflow

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

[Unreleased]: https://github.com/ramonsmits/NServiceBus.GuardNoActivity/compare/3.0.0...HEAD
[3.0.0]: https://github.com/ramonsmits/NServiceBus.GuardNoActivity/compare/2.0.0...3.0.0
[2.0.0]: https://github.com/ramonsmits/NServiceBus.GuardNoActivity/compare/1.0.0...2.0.0
[1.0.0]: https://github.com/ramonsmits/NServiceBus.GuardNoActivity/releases/tag/1.0.0
