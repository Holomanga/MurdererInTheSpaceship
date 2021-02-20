using Godot;
using System;

public class Impostor : KinematicBody2D
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";
    private int speed = 120;
    public Vector2 velocity = new Vector2();

    private AnimatedSprite sprite;
    public bool isPlayer = false;
    public bool isMongus = true;
    private int hitpoints = 3;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        sprite = GetNode<AnimatedSprite>("Sprite");
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {
    }

    public void GetInput() {
        velocity = new Vector2();


        if (Input.IsActionPressed("ui_right")) {
            velocity.x += 1;
        }
        if (Input.IsActionPressed("ui_left")) {
            velocity.x -= 1;
        }
        if (Input.IsActionPressed("ui_down")) {
            velocity.y += 1;
        }
        if (Input.IsActionPressed("ui_up")) {
            velocity.y -= 1;
        }

        velocity = velocity.Normalized() * speed;
    }

    public override void _PhysicsProcess(float delta)
    {
        if (isPlayer) {
            GetInput();
        }
        MoveAndSlide(velocity);

        if (velocity != new Vector2()) {
            if (sprite.Animation != "moving") {
                GD.Print("animation changed");
                sprite.Animation = "moving";
            }
        } else {
            sprite.Animation = "still";
        }
    }

    public void applyDamage(int damage) {
        hitpoints -= damage;
    }

}
