using UnityEngine;

public class Death : State
{
    public Death(StateMachine stateMachine, Character character) : base(stateMachine, character)
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
    }
}