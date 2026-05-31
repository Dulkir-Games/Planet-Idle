namespace PlanetIdle.core;

using Godot;

public static class PiLogger {

    public static void Debug(string foo) {
        GD.Print($"[DEBUG] {foo}");
    }

    public static void Info(string foo) {
        GD.Print($"[INFO] {foo}");
    }

    public static void Error(string foo) {
        GD.Print($"[ERROR] {foo}");
    }

}
