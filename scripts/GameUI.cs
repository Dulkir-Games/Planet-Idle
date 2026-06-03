using Godot;

namespace PlanetIdle.scripts;

// ReSharper disable once InconsistentNaming
public partial class GameUI : Control {

    [Export] private PackedScene _externalMassScene;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready() { }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta) { }

    private void OnSpawnMassPressed() {
        ExternalMass mass = this._externalMassScene.Instantiate<ExternalMass>();
        mass.SetSize(.1f);

        // todo this is terrible
        this.GetTree().Root.GetChild(1).AddChild(mass);
    }

}
