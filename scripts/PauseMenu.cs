using Godot;
using PlanetIdle.core;

namespace PlanetIdle.scripts;

public partial class PauseMenu : Control {

    [Export] private Control _pauseMenu;

    public override void _Ready() {
        base._Ready();
        Control pm = this._pauseMenu;
        if (pm is null) {
            PiLogger.Error("PauseMenu not assigned in editor!");
            return;
        }

        pm.Hide();
    }

    public override void _Input(InputEvent @event) {
        base._Input(@event);
        if (!@event.IsAction("Pause Menu") || @event.IsPressed()) {
            return;
        }

        this._pauseMenu.Visible = !this._pauseMenu.Visible;
    }

    private void OnResumeButtonPressed() {
        this._pauseMenu.Hide();
    }

    private void OnMainMenuButtonPressed() {
        this.GetTree().ChangeSceneToFile("res://scenes/menu/MainMenu.tscn");
    }

    private void OnQuitButtonPressed() {
        this.GetTree().Quit();
    }

}
