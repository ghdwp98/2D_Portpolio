using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ��� ���� Ŭ������ �⺻ Ŭ���� --> ����� �޼��带 ������ 
public class PlayerState
{
    protected PlayerStateMachine stateMachine;
    protected Player player;
    protected PlayerInput input;

    private string animBoolName;

    // ���¸ӽſ� ���� ���� 
    // Input�� ���Ե� �����ڸ� ���� 
    public PlayerState (PlayerInput input,  Player player , PlayerStateMachine stateMachine ,string animBoolName )
    {
        this.input = input; 
        this.player = player;
        this.stateMachine = stateMachine;
        this.animBoolName = animBoolName;
    }

    public virtual void Enter()
    {
        // ���� �� true / false ������ �ʿ��� �ִϸ��̼��� ��� �̿� 
        if(animBoolName != null)
        {
            player.Anim.SetBool(animBoolName, true); // �����ڿ��� �̹� �Ҵ��. 
        }
    }

    public virtual void Update()
    {

    }
    
    public virtual void LateUpdate()
    {

    }
    public virtual void Exit()
    {
        if (animBoolName != null)
        {
            player.Anim.SetBool(animBoolName, false); // �����ڿ��� �̹� �Ҵ��. 

        }
    }

    
}
