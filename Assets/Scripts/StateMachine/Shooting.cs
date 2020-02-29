using System.Collections;
using UnityEngine;

public class Shooting : State
{
    private CameraFollower camera;
    private Animator animator;

    public Shooting(StateMachine stateMachine, Character character, CameraFollower camera, Animator animator) : base(stateMachine, character)
    {
        this.camera = camera;
        this.animator = animator;
    }

    public override void Enter()
    {
        Time.timeScale = 0.4f;
        ShowWeaponLineShooting.OnStartTargeting?.Invoke();
        animator.SetTrigger("Jump");
    }

    public override void Exit()
    {
        ShowWeaponLineShooting.OnEndTargeting?.Invoke();
        Time.timeScale = 1f;
        animator.SetTrigger("Grounded");
    }

    public override void InputLogic()
    {
        if(Input.GetMouseButtonDown(0))
        {
            character.CharacterShoot();
        }
    }

    public override void LogicUpdate()
    {
    }

    public override void PhysicsUpdate()
    {
        character.Movement();
        character.RotateCharacter();
        camera.CameraMovement();
    }

}