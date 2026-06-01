using Godot;

namespace PlanetIdle.scripts;

public partial class DirectionalLight3D : Godot.DirectionalLight3D {

    public override void _PhysicsProcess(double delta) {
        base._PhysicsProcess(delta);
        this.Rotation += new Vector3(0f, 1f, 0f) * ((float)delta * .25f);
    }

}
