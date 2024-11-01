using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;

public class PlayerZattackState : PlayerState
{
    public PlayerZattackState(PlayerInput input, Player player, PlayerStateMachine stateMachine, string animBoolName) : base(input, player, stateMachine, animBoolName)
    {

    }

    public int comboAttackNumber; // 콤보 숫자 누적 
    public int MaxComboNumber = 2; // 3번까지 콤보가 가능하다. 
    public float comboAttackTimer; // 시간내에 눌러야 다음 코보 연결가능. 

    public float Timer = 0.7f;

    private bool nextComboInput = false; // 콤보 중 z키를 눌렀으면 다음 콤보로 이어져야 한다. 

    public override void Enter()
    {
        base.Enter();
        Debug.Log("Zattack 진입");
        comboAttackTimer = Timer;
        comboAttackNumber = 0;
    }

    public override void Exit()
    {
        base.Exit();
        triggerCalled = false; // 다시 False로 변경
        nextComboInput = false;

    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();

    }

    public override void LateUpdate()
    {
        base.LateUpdate();

    }

    public override void Update()
    {
        base.Update();
        comboAttackTimer -= Time.deltaTime;

        // 공격 상태 도중 다시 z키가 눌렸는지 확인. 

        if (input.actionsAsset["Zattack"].triggered)
        {
            nextComboInput = true;
        }

        // 어떠한 공격 애니메이션의 마지막 프레임이 실행 -> 연속공격 x or 종료 -> Idle 상태로 전환. 
        // 공격의 마지막 프레임에서 다음 콤보로 이어지는 키 입력이 들어올 경우에는 연속 공격 시작 
        if (triggerCalled)
        {
            if(comboAttackNumber >= MaxComboNumber || comboAttackTimer <=0  )
            {
                stateMachine.ChangeState(player.idleState);
                nextComboInput = false;
                ResetBoolParam();
            }
            else if (nextComboInput) // 마지막 프레임에 이미 z키를 한 번 더 누른상태 -> 콤보를 이어간다. 
            {
                PerformComboAttack();
                nextComboInput = false;
                triggerCalled = false;
                comboAttackTimer = Timer; // 다음콤보를 위한 시간 초기화 
            }
        }
    }

    private void PerformComboAttack()
    {
        ResetBoolParam();

        comboAttackNumber++;
        Debug.Log("콤보어택");
        switch(comboAttackNumber)
        {
            case 1:
                player.Anim.SetBool("Zattack2",true);
                break;
            case 2:
                player.Anim.SetBool("Zattack3", true);
                break;
        }
    }

    private void ResetBoolParam()
    {
        player.Anim.SetBool("Zattack1", false);
        player.Anim.SetBool("Zattack2", false);
        player.Anim.SetBool("Zattack3", false);
    }

}
