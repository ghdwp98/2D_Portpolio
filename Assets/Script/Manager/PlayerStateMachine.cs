using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ������ ���¸� �����ϰ� ���� ���̸� ó�� 
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
        // ���¸ӽ� ���� 
        currentState.Exit();
        currentState = newState;
        currentState.Enter();
    }



}
