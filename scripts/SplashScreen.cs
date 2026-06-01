using Godot;

namespace PlanetIdle.scripts;

public partial class SplashScreen : Control {

    private AnimationPlayer _animationPlayer;
    private Control _mainMenu;

    public override void _Ready() {
        this._animationPlayer = this.GetNode<AnimationPlayer>("AnimationPlayer");
        this._mainMenu = this.GetNode<Control>("MainMenu");

        this._animationPlayer.Play("MenuFadeIn");
    }

    public override void _Input(InputEvent @event) {
        base._Input(@event);
        if (!@event.IsPressed()) {
            return;
        }

        this._animationPlayer.Stop();
        this._mainMenu.Modulate = Colors.White;
    }

}
