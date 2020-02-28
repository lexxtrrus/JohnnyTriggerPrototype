using UnityEngine;

public class Running : State
{
    CameraFollower camera;

    public Running(StateMachine stateMachine, Character character, CameraFollower camera) : base(stateMachine, character)
    {
        this.camera = camera; 
    }

    public override void Enter()
    {
        base.Enter();
        Time.timeScale = 1f;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void InputLogic()
    {
        base.InputLogic();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        character.Movement();
        camera.CameraMovement();
    }
}