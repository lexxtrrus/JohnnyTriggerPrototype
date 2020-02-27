using UnityEngine;

public class Shooting : State
{
    public Shooting(StateMachine stateMachine, Character character) : base(stateMachine, character)
    {
        
    }

    public override void Enter()
    {
        base.Enter();
        WeaponShooting.OnStartTargeting?.Invoke();
    }

    public override void Exit()
    {
        base.Exit();
        WeaponShooting.OnEndTargeting?.Invoke();
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
    }
}