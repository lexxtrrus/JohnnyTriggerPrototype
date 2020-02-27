using UnityEngine;

public class Running : State
{
    public Running(StateMachine stateMachine, Character character) : base(stateMachine, character)
    {
        
    }

    public override void Enter()
    {
        base.Enter();
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
        //.RotateCharacter();
    }
}