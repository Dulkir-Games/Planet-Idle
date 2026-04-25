using Godot;

public partial class Ghost : Area2D {
	[Export] private float _speed = 90.0f;
	[Export] private Pacman _target;

	private Vector2 _direction;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready() {
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta) {
		Vector2 difference = _target.Position - Position;
		
		if (difference.Length() < _target.Radius) {
			_target.Kill();
		}

		if (Mathf.Abs(difference.X) > Mathf.Abs(difference.Y)) {
			difference.Y = 0.0f;
		}
		else {
			difference.X = 0.0f;
		}


		_direction = difference.Normalized();
		Position += (float)delta * _speed * _direction;
	}
}
