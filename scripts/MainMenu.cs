namespace PlanetIdle.scripts;

using Godot;

public partial class MainMenu : Control {

    public void OnPlayButtonPressed() {
        this.GetTree().ChangeSceneToFile("res://scenes/Game.tscn");
    }

}
