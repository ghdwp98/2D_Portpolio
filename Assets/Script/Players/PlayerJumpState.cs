using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerJumpState : PlayerAirState
{
    // 점프 키를 누르고 들어오는 점프상황. 
    // Ground State // Air State를 한 번 더 상속하는 방안도 생각필요. 
    public PlayerJumpState(PlayerInput input, Player player, PlayerStateMachine stateMachine, string animBoolName) : base(input, player, stateMachine, animBoolName)
    {

    }


    public override void Enter()
    {
        base.Enter();
        Debug.Log("JumpState 진입");
    }

    private void OnEnable()
    {
        
    }

    private void OnDisable()
    {
       
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LateUpdate()
    {
        base.LateUpdate();

    }

    public override void Update()
    {
        base.Update();
        

    }

}
