using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
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

    //요거  추가햄
    private void Update()
    {
        if (photonView.IsMine == false)
        {
            return;
        }
    
    }
    protected override void OnEnable()
    {
        // StatusController의 OnEnable() 실행 (상태 초기화)
        base.OnEnable();
    }

    // 체력 회복
    [PunRPC]
    public override void RestoreHP(int newHP)
    {
        base.RestoreHP(newHP);


    }

    // 데미지 처리
    [PunRPC]
    public override void OnDamage(int damage, Vector3 hitPoint, Vector3 hitDirection)
    {
        base.OnDamage(damage, hitPoint, hitDirection);

        //죽지않았고 , 닿으면 뒤로
        if (HP >= 0)
        {
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
            Debug.Log("100이다.임마");
        }
        else if (HP == 80)
        {
            hp100.SetActive(false);
            hp80.SetActive(true);
            Debug.Log("80이다.임마");
        }
        else if (HP == 60)
        {
            hp80.SetActive(false);
            hp60.SetActive(true);
            Debug.Log("60이다.임마");
        }
        else if (HP == 40)
        {
            hp60.SetActive(false);
            hp40.SetActive(true);
            Debug.Log("40이다.임마");
        }
        else if (HP == 20)
        {
            hp40.SetActive(false);
            hp20.SetActive(true);
            Debug.Log("20이다.임마");
        }
        else if (HP == 0)
        {
            hp20.SetActive(false);
            hp10.SetActive(true);
            Debug.Log("10이다.임마");
        }
        else
        {
            hp10.SetActive(false);
            hp0.SetActive(true);
            Debug.Log("0이다.임마");
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

        //3초 뒤에 리스폰
        Invoke("Respawn", 3);
        Debug.Log("부활");
    }
    //아이템 스크립트 오면 쓰자
    /*
    private void OnTriggerEnter(Collider other)
    {
        //아이템과 충돌한 경우 해당  아이템을 사용하는 처리
        //사망하지 않은 경우에만 아이템 사용 가능

        if (!dead)
        {

            //충돌한 상대방으로부터 Item 컴포넌트 가져오기 시도
            Item item = other.GetComponent<Item>();

            //충돌한 상대방으로부터 item 컴포넌트 가져오는 데 성공하였다면
            if (item != null)
            {
                //호스트 아이템 직접 사용 가능
                //호스트에서는 아이템 사용 후 사용된 아이템의 효과를 모든 클라이언트에 동기화 시킴
                if (PhotonNetwork.IsMasterClient)
                {
                    //use 메서드를 실행시켜 아이템 사용
                    
                }
            }
        }
    

    }
        */

    //부활 처리

    public void Respawn()
    {
        //로컬 플레이어만 직접 위치 변경 가능
        if (photonView.IsMine)
        {
            //원점에서 반경 5유닛 내부의 랜덤 위치 지정
            Vector3 randomSpawnPos = Random.insideUnitSphere * 9f;
            //랜덤 위치의 y값을 0으로 변경
            randomSpawnPos.y = 0f;

            //지정된 랜덤 위치로 이동
            transform.position = randomSpawnPos;


        }


        //컴포넌트를 리셋하기 위해 게임 오브젝트를 잠시 껐다고 다시 켜기
        //컴포넌트의 ondisable(), onEnable()메서드가 실행됨
        gameObject.SetActive(false);
        gameObject.SetActive(true);




    }
}
