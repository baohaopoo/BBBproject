using System;
using UnityEngine;
using UnityEngine.UI;

public class StatusController : MonoBehaviour, Damageable
{
    public int startHP = 100;
    public int HP { get; protected set; }
    public bool dead { get; protected set; }
    public event Action onDeath; //사망했을때 발동하는이벤트 

    //virtual : 가상메서드 ( 자식 클래스가 오버라이드 할 수 있도록 허용된 메서드 )
    // 자식클래스는 override로 부모클래스의 가상메서드를 재정의 가능 

    //활성화될때 실행
    protected virtual void OnEnable()
    {
        dead = false;
        HP = startHP;
    }

    //데미지를 입는다
    public virtual void OnDamage(int damage, Vector3 hitPoint, Vector3 hitNormal)
    {
        // 데미지만큼 체력 감소
        HP -= damage;

        if (HP < 0 && !dead)
        {
            Die();
        }
    }

    // 체력을 회복
    public virtual void RestoreHP(int newHP)
    {
        if (dead)
        {
            return;
        }

        // 체력 추가
        HP += newHP;
    }

    // 사망 처리
    public virtual void Die()
    {
        // onDeath 이벤트에 등록된 메서드가 있다면 실행
        if (onDeath != null)
        {
            onDeath();
        }

        // 사망 상태를 참으로 변경
        dead = true;
    }
}
