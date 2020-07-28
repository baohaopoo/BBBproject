using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Health : StatusController
{
    private AudioSource playerAudioPlayer; // 플레이어 소리 재생기
    private Animator playerAnimator; // 플레이어의 애니메이터
    private Rigidbody playerRigidbody; // 플레이어 캐릭터의 리지드바디


    //public Slider HPSlider; //체력 슬라이더 
    int x = 100;


    private void Start()
    {
        playerAnimator = GetComponent<Animator>();
        playerRigidbody = GetComponent<Rigidbody>();


    }

    protected override void OnEnable()
    {
        // StatusController의 OnEnable() 실행 (상태 초기화)
        base.OnEnable();

        UpdateUI();

    }

    // 체력 회복
    public override void RestoreHP(int newHP)
    {
        //StatusController의 RestoreHP 실행 (체력증가)
        base.RestoreHP(newHP);
        //체력 갱신 
        UpdateUI();
    }

    // 데미지 처리
    public override void OnDamage(int damage, Vector3 hitPoint, Vector3 hitDirection)
    {
        base.OnDamage(damage, hitPoint, hitDirection);
        
        //죽지않았고 , 닿으면 뒤로
        if (!dead)
        {
            playerAnimator.SetTrigger("Damaged");
            
            playerRigidbody.velocity = Vector3.zero; //속도 0으로하고
            playerRigidbody.AddForce(Vector3.right * -10, ForceMode.Impulse);//뒤로
        }

        UpdateUI();

    }

    //ui갱신 
    private void UpdateUI()
    {
        if (playerRigidbody != null && UIManager.instance != null)
        {
            UIManager.instance.UpdateHPSlider(HP);
        }
    }

    // 사망 처리
    public override void Die()
    {
        base.Die();
        //사망애니메이션
        playerAnimator.SetTrigger("Die");

        GameManager.instance.OnPlayerDead();

    }



}
