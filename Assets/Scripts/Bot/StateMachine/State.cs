using UnityEngine;

[RequireComponent(typeof(StateMachine))]
public abstract class State : MonoBehaviour
{
    [SerializeField] private State _nextState;

    protected StateMachine StateMachine;
    protected State NextState => _nextState;

    public void SetStateMachine(StateMachine stateMachine)
    {
        StateMachine = stateMachine;
    }

    protected void NeedTransit()
    {
        if (StateMachine != null)
            StateMachine.ChangeState(NextState);
    }
}