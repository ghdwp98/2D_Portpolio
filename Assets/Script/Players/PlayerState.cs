using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 모든 상태 클래스의 기본 클래스 --> 공통된 메서드를 정의함 
public class PlayerState
{
    protected PlayerStateMachine stateMachine;
    protected Player player;
    protected PlayerInput input;

    private string animBoolName;

    // 상태머신에 정보 전달 
    // Input이 포함된 생성자를 전달 
    public PlayerState (PlayerInput input,  Player player , PlayerStateMachine stateMachine ,string animBoolName )
    {
        this.input = input; 
        this.player = player;
        this.stateMachine = stateMachine;
        this.animBoolName = animBoolName;
    }

    public virtual void Enter()
    {
        // 진입 시 true / false 구분이 필요한 애니메이션인 경우 이용 
        if(animBoolName != null)
        {
            player.Anim.SetBool(animBoolName, true); // 생성자에서 이미 할당됨. 
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
            player.Anim.SetBool(animBoolName, false); // 생성자에서 이미 할당됨. 

        }
    }

    
}
