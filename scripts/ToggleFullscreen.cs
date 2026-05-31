using System;
using Godot;
using PlanetIdle.core;
using static Godot.DisplayServer;

namespace PlanetIdle.scripts;

public partial class ToggleFullscreen : Node {

    public override void _Input(InputEvent @event) {
        base._Input(@event);
        if (!@event.IsAction("Toggle Fullscreen") || !@event.IsPressed()) {
            return;
        }

        DisplayServerInstance dsi = Singleton;
        WindowMode cur = dsi.WindowGetMode();
        WindowMode next = this.Next(cur);
        PiLogger.Debug($"Switching window mode: {Enum.GetName(cur)} -> {Enum.GetName(next)}");
        dsi.WindowSetMode(next);
    }

    private WindowMode Next(WindowMode cur) {
        switch (cur) {
            case WindowMode.Minimized:
                PiLogger.Error("Tried to handle Fullscreen Toggle Press on minimized window.");
                return WindowMode.Windowed;
            case WindowMode.Windowed:
            case WindowMode.Maximized:
                return WindowMode.Fullscreen;
            case WindowMode.Fullscreen:
            case WindowMode.ExclusiveFullscreen:
                return WindowMode.Windowed;
            default:
                throw new ArgumentOutOfRangeException(nameof(cur), cur, null);
        }
    }

}
