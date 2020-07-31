﻿using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
public class Health : StatusController, IPunObservable
{
    private AudioSource playerAudioPlayer; // 플레이어 소리 재생기
    private Animator playerAnimator; // 플레이어의 애니메이터
    private Rigidbody playerRigidbody; // 플레이어 캐릭터의 리지드바디

    private PlayerController playercontroller; // 플레이어 움직임 컴포넌트
    private PlayerShooter playerShooter; // 플레이어 슈터 컴포넌트
    public bool isres = false;
    int x = 100;


    // 싱글톤 접근용 프로퍼티



    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {

        if (stream.IsWriting)
        {

            stream.SendNext(HP);

        }
        else
        {


            HP = (int)stream.ReceiveNext();
        
        }
    
    }
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
    public void OnEnable()
    {
        // StatusController의 OnEnable() 실행 (상태 초기화)
        base.OnEnable();
 
    }

    // 체력 회복

    [PunRPC]
    public override void RestoreHP(int newHP)
    {
        

        if (photonView.IsMine)
        {
            base.RestoreHP(newHP);
            //체력 갱신 
            UpdateUI();

        }


    }

    // 데미지 처리
    [PunRPC]
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

        if (photonView.IsMine)
        {

            Debug.Log("현재 체력은?????????");
            Debug.Log(HP);
            //갱신된 체력 슬라이더에 반영
            UpdateUI();


        }



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

        if (!photonView.IsMine)
        {
            return;
        }
        //status controller 의 Die의 실행(사망 적용)
        base.Die();

     
        //갱신된 체력 슬라이더에 반영
        UpdategameoverUI();

        //사망애니메이션
        playerAnimator.SetTrigger("Die");


        //즉으면 사망 유아이 틀고 키가 안먹어짐.
        UIManager.instance.die();

        if (!UIManager.instance.isready)
        {
            UIManager.instance.SetActiveGameoverUI(true);
        
        }

        Debug.Log("foresssssssssssssssssssss");
        //재시작 버튼누르면 버튼 스크립트가 알아서 연결될거고
        Debug.Log(UIManager.instance.isready);


        ///////////////////////////
        if (UIManager.instance.forres)
        {
            Debug.Log("여기까진 들어오겟지");
            //Invoke("Respawn",2f);
            Respawn();

            Debug.Log("너이놈!");
        }
        //////////////////////////////
        //Invoke("Respawn", 10f);
       
        //respawn함수 불러와
       // Respawn();

        //respawn함수에는 hp초기화, 애니메이션 사라, 인벤토리 초기화, bullet 초기화를 해주자.


    }
 
    private void UpdategameoverUI()
    {
        if (playerRigidbody != null && UIManager.instance != null)
        {
            UIManager.instance.SetActiveGameoverUI(true);
        }
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
        UIManager.instance.gameover = false;
       
        //로컬 플레이어만 직접 위치 변경 가능
       if (photonView.IsMine)
        {
            Debug.Log("뤼스폰 함수입니다.");
            //원점에서 반경 5유닛 내부의 랜덤 위치 지정
            Vector3 randomSpawnPos = Random.insideUnitSphere * 9f;
            //랜덤 위치의 y값을 0으로 변경
            randomSpawnPos.y = 0.8f;

            //지정된 랜덤 위치로 이동
            transform.position = randomSpawnPos;


            //헬스 초기화
            gameObject.SetActive(false);
            gameObject.SetActive(true);

            //UIManager.instance.UpdateHPSlider(100);
        }

 




    }
}
