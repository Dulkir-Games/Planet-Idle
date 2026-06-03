using Godot;
using System;

namespace PlanetIdle.scripts;

public partial class ExternalMass : Node3D {

    [Export] private MeshInstance3D _meshInstance3D;

    public override void _Ready() {
        base._Ready();
        this.SetPosition(GetRandomPos());
    }

    public void SetSize(float scalar) {
        this._meshInstance3D.SetScale(new Vector3(scalar, scalar, scalar));
    }

    private static Vector3 GetRandomPos() {
        // todo make this better
        var dir = new Vector3(
            (float)(Random.Shared.NextDouble() * 2 - 1),
            (float)(Random.Shared.NextDouble() * 2 - 1),
            0
        ).Normalized();

        return dir * 0.7f;
    }

}
