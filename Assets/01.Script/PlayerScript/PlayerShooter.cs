using UnityEngine;
using Photon.Pun;
// 주어진 Gun 오브젝트를 쏘거나 재장전
public class PlayerShooter : MonoBehaviourPun
{
  //public Gun gunscript; //실험

    public Gun gun; // 사용할 총

    private PlayerController playerController;
    private PlayerInput playerInput;
    private Animator playerAnimator;
    private CameraController cameraController;

    //에임 
    public Animator CrossHairAnimator;

    
    //에임 유아이
    public GameObject CrossHairUI;

    private void Start()
    {
        // 사용할 컴포넌트들을 가져오기
        //CrossHairUI = GameObject.FindGameObjectWithTag("Crosshair"); 
        playerController = GetComponent<PlayerController>();
        playerInput = GetComponent<PlayerInput>();
        playerAnimator = GetComponent<Animator>();
        cameraController = GetComponent<CameraController>();

  
        gun.transform.rotation = FindObjectOfType<PlayerController>().transform.rotation;
    }

    private void OnEnable()
    {
     
      
        
        //총이 쏴질때.
        photonView.RPC("gunon_RPC", RpcTarget.All);


        if (photonView.IsMine)
        {
            //에임 UI도 활성화
            gun.Aimon();

            if (gun.bulletRemain <= 0)
            {
                //총알상태를 off
                gun.Stateoff();
            }else if (gun.bulletRemain > 0)
            {
                gun.Stateon();
            }

            // Aim.SetActive(false);

          
        }

    }
    [PunRPC]
    public void gunon_RPC()
    {

        // 슈터가 활성화될 때 총도 함께 활성화
        gun.gameObject.SetActive(true);
      
        //if (gunscript.bulletRemain == 5)
        //{
        //    gunscript.BulletUI();
        //}
        

    }

    private void OnDisable()
    {
        photonView.RPC("gunoff_RPC", RpcTarget.All);
        //에임 비활성화

        if (photonView.IsMine) //포톤이 로컬일떄
        {
            gun.Aimoff();

        }
    }
    [PunRPC]
    void gunoff_RPC()
    {

        // 슈터가 비활성화될 때 총도 함께 비활성화
        gun.gameObject.SetActive(false);


    }


    private void Update()
    {


        rotateGun();
        animations();


        //UpdateUI(); //남은 탄알 업데이트
        //로컬 플레이어만 총을 직접 사격.탄알UI 갱신가능
        //if (!photonView.IsMine)
        //{
        //    return;

        //}

    }

    //에임 애니메이션 

    private void animations()
    {
        if (playerInput.Verticalmove >= 1f)
        {
            CrossHairAnimator.SetBool("Walking", true);
    
            if (playerInput.fire)//&&gun.bulletRemain!=0)
            {
                CrossHairAnimator.SetTrigger("walk_Fire");
                gun.Fire();
            }
        }
        else
        {
            CrossHairAnimator.SetBool("Walking", false);
            if (playerInput.fire)// && gun.bulletRemain != 0)
            {
                CrossHairAnimator.SetTrigger("Idle_Fire");
                gun.Fire();
            }
        }

    }
    private void rotateGun()
    {
        gun.transform.rotation = FindObjectOfType<CameraController>().transform.rotation;
    }


}