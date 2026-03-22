# Welcome to Logi Actions SDK

Here you can find an introduction to Logi Actions SDK, example plugin source code and the SDK documentation.

## Documentation

- [Logi Actions SDK Developer Docs](https://logitech.github.io/actions-sdk-docs/)
- [Logi Developer Discord](https://discord.gg/ptV2BfHCmm)

---

# DemoPlugin

A Logitech Actions SDK plugin built with C# (.NET 8) that works on both macOS and Windows. This project is intended as a learning resource for new developers joining the team — each file is structured and commented to help you understand how the SDK works.

## Folder Structure

```
DemoPlugin/
├── .vscode/        # VS Code setup — debugger config to attach to the Logi Plugin Service
│                   # and build tasks for quick builds, packaging and installing
├── src/
│   ├── Actions/    # Where all commands and adjustments live.
│                   # Each file is one feature assigned to a button or dial
│   ├── Helpers/    # Shared utility classes used across all actions.
│                   # PluginLog for logging, PluginResources for loading images
│   ├── images/     # PNG icons embedded into the plugin DLL.
│                   # These are displayed on device buttons at runtime
│   └── package/    # Plugin identity files read by the Logi Plugin Service
│                   # on startup — name, version, icon and supported devices
└── bin/            # Auto-generated build output. Never edit this folder manually.
```

## Actions

| Action | Type | Description |
|---|---|---|
| Toggle Mute | Button | Mutes and unmutes system volume on macOS and Windows |
| Button Switches | Button | 4 independent on/off toggle switches |
| Thumb Up/Down | Button | Toggles between thumb up and thumb down image |
| Counter | Dial | Counts rotation ticks, press dial to reset |

## Build

```bash
# Debug — used during development and debugging
dotnet build -c Debug

# Release — used for packaging and distribution
dotnet build -c Release
```

## Debug

1. Open the project in VS Code
2. Run `dotnet build -c Debug`
3. Go to **Run > Start Debugging** (or press `F5`)
4. Select **Attach to Logi Plugin Service**

You can now set breakpoints in any action file and step through your code live.

## Package & Install

```bash
# Package the plugin into a distributable .lplug4 file
logiplugintool pack ./bin/Release ./Demo.lplug4

# Install the plugin on this machine
logiplugintool install ./Demo.lplug4

# Uninstall the plugin
logiplugintool uninstall Demo
```
