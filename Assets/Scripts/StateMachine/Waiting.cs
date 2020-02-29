using UnityEngine;

public class Waiting : State
{
    private Animator animator;

    public Waiting(StateMachine stateMachine, Character character, Animator animator) : base(stateMachine, character)
    {
        this.animator = animator;
    }

    public override void Enter()
    {
        Time.timeScale = 1f;
        animator.SetInteger("Speed", 0);
    }

    public override void Exit()
    {
    }

    public override void InputLogic()
    {
        if(Input.GetMouseButtonDown(0))
        {
            TapForStartCheck.OnTapForStartAction?.Invoke();
            stateMachine.ChangeState(character.runningState);
            animator.SetInteger("Speed", 1);
        }
    }

    public override void LogicUpdate()
    {

    }

    public override void PhysicsUpdate()
    {

    }
}