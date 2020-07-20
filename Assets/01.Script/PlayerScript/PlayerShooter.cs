using UnityEngine;
using Photon.Pun;
// 주어진 Gun 오브젝트를 쏘거나 재장전
public class PlayerShooter : MonoBehaviourPun
{
    GameObject playerGrabPoint;
    public Gun gun; // 사용할 총

    private PlayerController playerController;
    private PlayerInput playerInput;
    private Animator playerAnimator;
    private MainCameraController cameraController;


    public Animator CrossHairAnimator;

    public GameObject CrossHairUI;

    private void Start()
    {
        // 사용할 컴포넌트들을 가져오기
        playerGrabPoint = GameObject.FindGameObjectWithTag("grabPoint"); //플레이어 총잡을 부분 객체 소환
        playerController = GetComponent<PlayerController>();
        playerInput = GetComponent<PlayerInput>();
        playerAnimator = GetComponent<Animator>();
        cameraController = GetComponent<MainCameraController>();

        //총을 자식으로 두고 위치갱신 
        gun.transform.SetParent(playerGrabPoint.transform);
        gun.transform.localPosition = new Vector3(-0.53f, -0.82f, 0.22f);
        gun.transform.rotation = FindObjectOfType<PlayerController>().transform.rotation;
    }

    private void OnEnable()
    {
        photonView.RPC("gunon_RPC", RpcTarget.All);

        //에임 UI도 활성화
        CrossHairUI.SetActive(true);


    }
    [PunRPC]
    void gunon_RPC()
    {

        // 슈터가 활성화될 때 총도 함께 활성화
        this.gun.gameObject.SetActive(true);


    }

    private void OnDisable()
    {
        photonView.RPC("gunoff_RPC", RpcTarget.All);
        //에임 비활성화
        CrossHairUI.gameObject.SetActive(false);
        Debug.Log("에임 활성화 되고있냐");

    }

    void gunoff_RPC()
    {

        // 슈터가 비활성화될 때 총도 함께 비활성화
        this.gun.gameObject.SetActive(false);


    }


    private void Update()
    {


        rotateGun();
        animations();


        //UpdateUI(); //남은 탄알 업데이트
        //로컬 플레이어만 총을 직접 사격. 탄알UI 갱신가능
        //if (!photonView.IsMine)
        //{
        //    return;

        //}

    }

    private void animations()
    {
        if (playerInput.Verticalmove >= 1f)
        {
            CrossHairAnimator.SetBool("Walking", true);
    
            if (playerInput.fire&&gun.bulletRemain!=0)
            {
                CrossHairAnimator.SetTrigger("walk_Fire");
                gun.Fire();
            }
        }
        else
        {
            CrossHairAnimator.SetBool("Walking", false);
            if (playerInput.fire && gun.bulletRemain != 0)
            {
                CrossHairAnimator.SetTrigger("Idle_Fire");
                gun.Fire();
            }
        }

    }
    private void rotateGun()
    {
        gun.transform.rotation = FindObjectOfType<MainCameraController>().transform.rotation;
    }


    // 탄약 UI 갱신
    //private void UpdateUI()
    //{
    //    //if (gun != null && UIManager.instance != null)
    //    //{
    //    //    // UI 매니저의 탄약 텍스트에 탄창의 탄약과 남은 전체 탄약을 표시
    //    //    UIManager.instance.UpdateAmmoText(gun.magAmmo, gun.ammoRemain);
    //    //}
    //}

}