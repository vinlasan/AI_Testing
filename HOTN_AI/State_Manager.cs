using UnityEngine;
using System.Collections;

public class State_Manager<T> {

    T owner;
    NPC_State<T> _currState, _prevState, _glblState;

    public State_Manager(T npc)
    {
        owner = npc;
        _currState = null;
        _prevState = null;
        _glblState = null;
    }

    public void UpdateState()
    {
        if (_glblState != null) _glblState.Execute(owner);

        if (_currState != null) _currState.Execute(owner);
    }

    public void ChangeState(NPC_State<T> newState)
    {
        if (_currState == null) _currState = newState;
        if (newState != null)
        {
            _prevState = _currState;
            _currState.Exit(owner);
            _currState = newState;
            _currState.Enter(owner);
        }
    }

    public void RevertPrevState()
    {
        ChangeState(_prevState);
    }

}
