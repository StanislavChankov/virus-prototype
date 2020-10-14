# virus-prototype
Very simple game built with MonoGame.

## Build Status
![.NET Core](https://github.com/StanislavChankov/virus-prototype/workflows/.NET%20Core/badge.svg)

## Sprite assets
https://www.gameart2d.com/the-knight-free-sprites.html

## Setup
1. Download sprites - `Sprites.rar` from https://drive.google.com/drive/folders/1zBbtIv7W65V26dTWXQMJM5UW0aKcYEfB?usp=sharing
2. Extract them into the source code of the project into `src/Synergy.VirusPrototype.Shared/Content/2d`
3. Open Visual Studio and update the properties of the files.
3.1. `Build Action`: `Content`
3.2 `Copy to output diretory`: `Copy if newer`

## Design Patterns, practices, etc. to implement
1. [ ] Model-View-Update.
2. [x] Dependency Injection.
3. [x] Shared configurations between platforms in one `appsettings.json`.
4. [ ] Support multiple environments.
5. [ ] Setup test project with example tests for the Shared project.
6. [ ] Add code coverage report from CodeCov.
7. [x] Setup Continuous Integration with Github Actions.
8. [] Usage of MediatR.
