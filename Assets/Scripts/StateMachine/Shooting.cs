using System.Collections;
using UnityEngine;

public class Shooting : State
{
    private CameraFollower camera;

    public Shooting(StateMachine stateMachine, Character character, CameraFollower camera) : base(stateMachine, character)
    {
        this.camera = camera;
    }

    public override void Enter()
    {
        base.Enter();
        ShowWeaponLineShooting.OnStartTargeting?.Invoke();
    }

    public override void Exit()
    {
        base.Exit();
        ShowWeaponLineShooting.OnEndTargeting?.Invoke();
        Time.timeScale = 1f;
    }

    public override void InputLogic()
    {
        base.InputLogic();
        if(Input.GetMouseButtonDown(0))
        {
            character.CharacterShoot();
        }
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        character.Movement();
        character.RotateCharacter();
        camera.CameraMovement();
    }

}