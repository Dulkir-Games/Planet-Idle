using Godot;
using System;

public partial class Pacman : Area2D {
	
	[Signal] public delegate void HitEventHandler();

	[Export] private float _speed = 100.0f;
	[Export] private Color _hitColor = new() { R = 1.0f, G = 0.0f, B = 0.0f, A = 1.0f };
	[Export] private float _flashTime = 0.5f;
	[Export] private float _radius = 100.0f;
	public float Radius => _radius;
	private Vector2 _direction = Vector2.Zero;
	
	private Polygon2D _polygon2D;
	private Color _originalColor;

	private Vector2 _topLipPosition;
	private Vector2 _bottomLipPosition;

	private float _timeLastHit = -Mathf.Inf;

	private float _t = 0.0f;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready() {
		base._Ready();
		_polygon2D = GetNode<Polygon2D>("Polygon2D");

		_originalColor = _polygon2D.Color;
		_topLipPosition = _polygon2D.Polygon[1];
		_bottomLipPosition = _polygon2D.Polygon[7];
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta) {
		base._Process(delta);
		if (Input.IsActionPressed("move_right")) {
			Rotation = Mathf.DegToRad(0.0f);
			_direction = new Vector2(1.0f, 0.0f);	
		}
		if (Input.IsActionPressed("move_left")) {
			Rotation = Mathf.DegToRad(180.0f);
			_direction = new Vector2(-1.0f, 0.0f);	
		}
		if (Input.IsActionPressed("move_up")) {
			Rotation = Mathf.DegToRad(270.0f);
			_direction = new Vector2(0.0f, -1.0f);	
		}
		if (Input.IsActionPressed("move_down")) {
			Rotation = Mathf.DegToRad(90.0f);
			_direction = new Vector2(0.0f, 1.0f);	
		}

		Position += (float)delta * _speed * _direction;

		_t += (float)delta;
		float t = (Mathf.Sin(_t * 20.0f) + 1.0f) / 2.0f;

		Vector2[] polygons = _polygon2D.Polygon;
		polygons[1] = new Vector2(_topLipPosition.X, _topLipPosition.Y * t);
		polygons[7] = new Vector2(_bottomLipPosition.X, _bottomLipPosition.Y * t);
		_polygon2D.Polygon = polygons;

		_polygon2D.Color = _hitColor.Lerp(_originalColor, Mathf.Clamp((_t - _timeLastHit) / _flashTime, 0.0f, 1.0f));

		if (Position.X > GetViewportRect().Size.X + _radius)
			Position = new Vector2(-_radius, Position.Y);
		else if (Position.X < -_radius)
			Position = new Vector2(GetViewportRect().Size.X + _radius, Position.Y);
		
		if (Position.Y > GetViewportRect().Size.Y + _radius)
			Position = new Vector2(Position.X, -_radius);
		else if (Position.Y < -_radius)
			Position = new Vector2(Position.X, GetViewportRect().Size.Y + _radius);

	}

	public void Kill() {
		_timeLastHit = _t;

		Random random = new();
		Position = new Vector2(
			random.NextSingle() * GetViewportRect().Size.X + GetViewportRect().Position.X, 
			random.NextSingle() * GetViewportRect().Size.Y + GetViewportRect().Position.Y
		);
	}

}
