using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationTriggers : MonoBehaviour
{
    // 표현식 본문 -> Get 프로퍼티와 같은 역할 
    Player player => GetComponentInParent<Player>();

    public Collider2D [] zAttackCollider;
    

    [SerializeField]
    private LayerMask monsterLayer;

    private void Start()
    {
        ColliderRegist();
    }

    // 애니메이션 프레임의 마지막에 등록하여 해당 애니메이션의 끝난 상황을 체크
    public void AnimationTrigger()
    {
        player.AnimationTrigger(); 
    }

    // 이 부분 이벤트 발생 시 몬스터가 맞아야 함. ->데미지 타이밍 이벤트
    public void AttackTrigger()
    {
        // zAttackCollider1.enabled = true;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }

    private void ColliderRegist()
    {
        foreach (var collider in zAttackCollider)
        {
            if (collider != null)
            {
                collider.enabled = false; // 시작 시 모든 콜라이더 비활성화
            }
        }

    }


}
