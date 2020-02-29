using UnityEngine;

public class Running : State
{
    private CameraFollower camera;
    private Animator animator;

    public Running(StateMachine stateMachine, Character character, CameraFollower camera, Animator animator) : base(stateMachine, character)
    {
        this.camera = camera;
        this.animator = animator;
    }

    public override void Enter()
    {
        Time.timeScale = 1f;
    }

    public override void Exit()
    {
    }

    public override void InputLogic()
    {
    }

    public override void LogicUpdate()
    {
    }

    public override void PhysicsUpdate()
    {
        character.Movement();
        camera.CameraMovement();
    }
}