using Godot;
using System;

public class Task {
    public Subsystem associatedSubsystem;
    public bool completed = false;
    public string name;
    
    public Task(Subsystem subsystem, string taskName) {
        associatedSubsystem = subsystem;
        name = taskName;
    } 

    public string TaskString() {
        return name;
    }
}