using System;
using Godot;
using PlanetIdle.core;

namespace PlanetIdle.scripts;

public partial class ToggleFullscreen : Node {

    public override void _Input(InputEvent @event) {
        base._Input(@event);
        if (!@event.IsAction("Toggle Fullscreen") || !@event.IsPressed()) {
            return;
        }
        DisplayServerInstance dsi = DisplayServer.Singleton;
        DisplayServer.WindowMode cur = dsi.WindowGetMode();
        DisplayServer.WindowMode next = this.Next(cur);
        PiLogger.Debug($"Switching window mode: {Enum.GetName(cur)} -> {Enum.GetName(next)}");
        dsi.WindowSetMode(next);
    }

    private DisplayServer.WindowMode Next(DisplayServer.WindowMode cur) {
        switch (cur) {
            case DisplayServer.WindowMode.Minimized:
                PiLogger.Error("Tried to handle Fullscreen Toggle Press on minimized window.");
                return DisplayServer.WindowMode.Windowed;
            case DisplayServer.WindowMode.Windowed:
            case DisplayServer.WindowMode.Maximized:
                return DisplayServer.WindowMode.Fullscreen;
            case DisplayServer.WindowMode.Fullscreen:
            case DisplayServer.WindowMode.ExclusiveFullscreen:
                return DisplayServer.WindowMode.Windowed;
            default:
                throw new ArgumentOutOfRangeException(nameof(cur), cur, null);
        }
    }

}
