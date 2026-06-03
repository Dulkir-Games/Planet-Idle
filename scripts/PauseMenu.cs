using Godot;

namespace PlanetIdle.scripts;

public partial class PauseMenu : Control {

    public override void _Ready() {
        base._Ready();
        this.Hide();
    }

    public override void _Input(InputEvent @event) {
        base._Input(@event);
        if (!@event.IsAction("Pause Menu") || @event.IsPressed()) {
            return;
        }

        this.ToggleVisibility();
    }

    private void OnResumeButtonPressed() {
        this.Hide();
    }

    private void OnMainMenuButtonPressed() {
        this.GetTree().ChangeSceneToFile("res://scenes/menu/MainMenu.tscn");
    }

    private void OnQuitButtonPressed() {
        this.GetTree().Quit();
    }

    private void ToggleVisibility() {
        if (this.Visible) {
            this.Hide();
        }
        else {
            this.Show();
        }
    }

}
