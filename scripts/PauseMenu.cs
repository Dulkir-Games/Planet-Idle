using Godot;
using PlanetIdle.core;
using System;

namespace PlanetIdle.scripts;

public partial class PauseMenu : Control {

	[Export] private Control _pauseMenu;

	public override void _Ready() {
		base._Ready();
		if (this._pauseMenu == null) {
			PiLogger.Error("PauseMenu not assigned in editor!");
		}
        this._pauseMenu.Hide();
	}

	public override void _Input(InputEvent @event) {
		base._Input(@event);
		if (!@event.IsAction("Pause Menu") || @event.IsPressed()) {
			return;
		}

        this._pauseMenu.Visible = !this._pauseMenu.Visible;
	}

	public void OnResumeButtonPressed() {
        this._pauseMenu.Hide();
	}

	public void OnMainMenuButtonPressed() {
        this.GetTree().ChangeSceneToFile("res://scenes/MainMenu.tscn");
	}

}
