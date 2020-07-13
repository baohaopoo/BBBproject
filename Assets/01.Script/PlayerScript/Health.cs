using UnityEngine;
using UnityEngine.UI;

public class Health : StatusController
{
    private AudioSource playerAudioPlayer; // 플레이어 소리 재생기
    private Animator playerAnimator; // 플레이어의 애니메이터
    private Rigidbody playerRigidbody; // 플레이어 캐릭터의 리지드바디

    private PlayerController playercontroller; // 플레이어 움직임 컴포넌트
    private PlayerShooter playerShooter; // 플레이어 슈터 컴포넌트
    public GameObject HPImage;
    int x = 100;


    public GameObject hp100;
    public GameObject hp80;
    public GameObject hp60;
    public GameObject hp40;
    public GameObject hp20;
    public GameObject hp10;
    public GameObject hp0;

    private void Start()
    {
        playerAnimator = GetComponent<Animator>();
        playerRigidbody = GetComponent<Rigidbody>();
    }

    protected override void OnEnable()
    {
        // StatusController의 OnEnable() 실행 (상태 초기화)
        base.OnEnable();
    }

    // 체력 회복
    public override void RestoreHP(int newHP)
    {
        base.RestoreHP(newHP);


    }

    // 데미지 처리
    public override void OnDamage(int damage, Vector3 hitPoint, Vector3 hitDirection)
    {
        base.OnDamage(damage, hitPoint, hitDirection);

        //죽지않았고 , 닿으면 뒤로
        if (HP >= 0) {
            playerAnimator.SetTrigger("Damaged");
            playerRigidbody.velocity = Vector3.zero;
            playerRigidbody.AddForce(Vector3.right * -10, ForceMode.Impulse);
        }


        //갱신된 체력으로 이미지 색깔 변신
        if (HP < 20)
        {
            HPImage.GetComponent<Image>().color = new Color(1, 0, 0);
        }
        if (HP == 100)
        {
            hp100.SetActive(true);
        }
        else if (HP == 80)
        {
            hp100.SetActive(false);
            hp80.SetActive(true);
        }
        else if (HP == 60)
        {
            hp80.SetActive(false);
            hp60.SetActive(true);
        }
        else if (HP == 40)
        {
            hp60.SetActive(false);
            hp40.SetActive(true);
        }
        else if (HP == 20)
        {
            hp40.SetActive(false);
            hp20.SetActive(true);
        }
        else if (HP == 0)
        {
            hp20.SetActive(false);
            hp10.SetActive(true);
        }
        else
        {
            hp10.SetActive(false);
            hp0.SetActive(true);
            Die();
        }
    }

    // 사망 처리
    public override void Die()
    {
        base.Die();
        HPImage.SetActive(false);
        playerAnimator.SetTrigger("Die");
        GameManager.instance.OnPlayerDead();
    }


  
}
