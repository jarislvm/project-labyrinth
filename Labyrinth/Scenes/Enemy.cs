using Godot;
using System;

public partial class Enemy : AnimatedSprite2D
{
 // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        // Ensure the default animation is "idle"
        Animation = "idle";
        // Connect the input event
        SetProcessInput(true);
    }

    public override void _Input(InputEvent @event)
    {
        // Check if the event is a mouse button press and if the left button is pressed
        if (@event is InputEventMouseButton mouseEvent && mouseEvent.Pressed && mouseEvent.ButtonIndex == MouseButton.Left)
        {
            // Check if the mouse is over the sprite
            if (IsMouseOver(mouseEvent.Position))
            {
                // Change the animation to "attack"
                Animation = "attack";
                Play(Animation);
            }
        }
    }

    private bool IsMouseOver(Vector2 mousePosition)
    {
        Vector2 localMousePosition = ToLocal(mousePosition);
        var currentFrame = SpriteFrames.GetFrameTexture(Animation, Frame);
        Rect2 spriteRect = new Rect2(Vector2.Zero, currentFrame.GetSize());
        return spriteRect.HasPoint(localMousePosition);
    }

    public override void _Process(double delta)
    {
        // Optional: Change back to idle animation after the attack animation finishes
        if (Animation == "attack" && !IsPlaying())
        {
            Animation = "idle";
            Play(Animation);
						
        }
    }
}
