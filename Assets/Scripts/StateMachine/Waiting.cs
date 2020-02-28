using UnityEngine;

public class Waiting : State
{
    public Waiting(StateMachine stateMachine, Character character) : base(stateMachine, character)
    {
        
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
        if(Input.GetMouseButtonDown(0))
        {
            TapForStartCheck.OnTapForStartAction?.Invoke();
            stateMachine.ChangeState(character.runningState);
        }
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