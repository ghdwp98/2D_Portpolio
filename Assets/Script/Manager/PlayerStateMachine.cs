using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 현재의 상태를 관리하고 상태 전이를 처리 
public class PlayerStateMachine
{
    public PlayerState currentState { get; private set; }

    public void InitialIze (PlayerState startState)
    {
        currentState = startState;
        currentState.Enter(); 

    }

    public void ChangeState(PlayerState newState)
    {
        // 상태머신 전이 
        currentState.Exit();
        currentState = newState;
        currentState.Enter();
    }



}
