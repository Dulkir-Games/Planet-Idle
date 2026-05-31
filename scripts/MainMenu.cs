using Godot;

namespace PlanetIdle.scripts;

public partial class MainMenu : Control {

    public void OnPlayButtonPressed() {
        this.GetTree().ChangeSceneToFile("res://scenes/Game.tscn");
    }

}
