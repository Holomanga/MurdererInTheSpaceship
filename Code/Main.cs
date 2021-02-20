using Godot;
using System;

public class Main : Node2D
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";
    [Export] public PackedScene Impostor;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        var newImpostor = (Impostor)Impostor.Instance();
        newImpostor.isPlayer = true;
        newImpostor.isMongus = true;
        AddChild(newImpostor);
        var camera = new Camera2D();
        camera.Current = true;
        newImpostor.AddChild(camera);
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
