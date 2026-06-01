using Godot;

namespace PlanetIdle.scripts;

public partial class MainMenu : Control {

    private void OnPlayButtonPressed() {
        this.GetTree().ChangeSceneToFile("res://scenes/Game.tscn");
    }

    private void OnQuitButtonPressed() {
        this.GetTree().Quit();
    }

}
