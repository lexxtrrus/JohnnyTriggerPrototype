using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State 
{
    public State(StateMachine stateMachine, Character character)
    {
        this.stateMachine = stateMachine;
        this.character = character;
    }
    protected StateMachine stateMachine;
    protected Character character;

    public virtual void Enter(){}
    public virtual void InputLogic(){}
    public virtual void LogicUpdate(){}
    public virtual void PhysicsUpdate(){}
    public virtual void Exit(){}
}
