using UnityEngine;

public class StateMachine : MonoBehaviour
{
    [SerializeField] private State _firstState;

    private State currentState;

    private void Start()
    {
        if (_firstState != null)
            ChangeState(_firstState);
    }
    
    public void ChangeState(State newState)
    {
        if (currentState != null)
            currentState.enabled = false;

        currentState = newState;

        currentState.SetStateMachine(this);
        currentState.enabled = true;
    }
}