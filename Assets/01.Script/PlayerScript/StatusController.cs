using System;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
public class StatusController : MonoBehaviourPun, Damageable
{
    public int startHP = 100;
    public int HP { get; protected set; }
    public bool dead { get; protected set; }
    public event Action onDeath; //사망했을때 발동하는이벤트 

    //virtual : 가상메서드 ( 자식 클래스가 오버라이드 할 수 있도록 허용된 메서드 )
    // 자식클래스는 override로 부모클래스의 가상메서드를 재정의 가능 



    //호스트 -> 모든 클라이언트 방향으로 체력과 사망 상태를 동기화하는 메서
    [PunRPC]
    public void ApplyUpdateHealth(int newHealth, bool newDead)
    {

        HP = newHealth;
        dead = newDead;
    }
    //활성화될때 실행
    protected virtual void OnEnable()
    {
        dead = false;
        HP = startHP;
    }
    [PunRPC]
    //데미지를 입는다
    public virtual void OnDamage(int damage, Vector3 hitPoint, Vector3 hitNormal)
    {
        //호스트에서만 실행됨
        if (PhotonNetwork.IsMasterClient)
        {
            // 데미지만큼 체력 감소
            HP -= damage;

            //호스트에서 클라이언트로 동기화
            photonView.RPC("ApplyUpdateHealth", RpcTarget.Others, HP, dead);
            //다른 클라이언트도 onDamage를 실행하도록 함
            photonView.RPC("OnDamage", RpcTarget.Others, damage, hitPoint, hitNormal);
        }

        //체력 0 이하 && 아직 죽지 않았다면 실행하도록 함
        if (HP < 0 && !dead)
        {
            Die();
        }
    }
    [PunRPC]
    // 체력을 회복
    public virtual void RestoreHP(int newHP)
    {
        if (dead)
        {
            //이미 사망한 경우 체력을 회복할 수 없음
            return;
        }

        if (PhotonNetwork.IsMasterClient)
        {

            // 체력 추가
            HP += newHP;

            //서버에서 클라이언트로 동기화
            photonView.RPC("ApplyUpdateHealth", RpcTarget.Others, HP, dead);
            //다른 클라이언트도 RestoreHealth 를 실행하도록 함
            photonView.RPC("RestoreHealth", RpcTarget.Others, newHP);



        }
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
