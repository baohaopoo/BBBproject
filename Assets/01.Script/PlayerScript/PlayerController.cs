using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Utility;

public class PlayerController : MonoBehaviourPun
{
    public float startmoveSpeed = 7f;
    public float rotateSpeed = 80f;
    float moveSpeed;
    public float lookSensitivity = 3f;//마우스 민감도

    public float jumpPower = 16f;
    
    private PlayerShooter playershooter;
    private PlayerInput playerInput; 
    private Rigidbody playerRigidbody;
    private Transform playerTranform;
    private Animator playerAnimator;
    private PlayerPunch playerpunch;
    public GameObject FollowCam; //maincam
    public GameObject ForwardCam; //F키 눌를떄
    public GameObject FirstPlayerCam;
    public GameObject PlayerPibot; //플레이어의 피봇


    //플레이어 파티클
    public ParticleSystem pusheffect; //닿으면 나올 파티클

   // public GameObject Timeline;

    bool isGrounded;
    bool isPicking;
    bool isRope;
    bool isForwardcam;
    bool isGunViewcam;
    private bool isUseGun;

    bool upRope;
    bool noGravity;
    int jumpcount;


    GameObject PlayerGrabPoint; //플레이어 아이템 잡을 때 쓰는 객체변수 생성
    Collider col;
    GameObject rope; //플레이어 로프와 닿으면 수평이동 제한.
    GameObject ropeCollision;



    GameObject friend;


  
    private bool isAir;


    int rightmouseCnt=0; //오른쪽마우스 두번누르면 1인칭시점 취소시키기위해 만든변수

    void Awake()
    {
        //죽지마 플레이어야!!
        DontDestroyOnLoad(gameObject);

    }
    void Start()
    {


        //GetComponent<SmoothFollow>().target = PlayerPibot.transform;
        //Camera.main.GetComponent<SmoothFollow>().target = PlayerPibot.transform;

        //if  (Camera.main.GetComponent<SmoothFollow>().target == gameObject)
        //{
        //    Debug.Log("잘들어오고 있니?");
        //}
        if (Camera.main.GetComponent<SmoothFollow>().target)
        {
            Debug.Log("잘들어오고 있니?");
        }
        playerTranform = GetComponent<Transform>();
        playershooter = GetComponent<PlayerShooter>();
        playerInput = GetComponent<PlayerInput>();
        playerRigidbody = GetComponent<Rigidbody>();
        playerAnimator = GetComponent<Animator>();
        playerpunch = GetComponent<PlayerPunch>();
        PlayerGrabPoint = GameObject.FindGameObjectWithTag("grabPoint"); //PlayerGrabPoint 객체 소환
        col = gameObject.GetComponent<Collider>();

        rope = GameObject.FindGameObjectWithTag("rope"); //rope객체 소환
        ropeCollision = GameObject.FindGameObjectWithTag("ropeCollision");


        upRope = false;
        noGravity = false;
        isRope = false;
        isForwardcam = false;
        isGunViewcam = false;
        isUseGun = false;

    }

    // Update is called once per frame
    void Update()
    {
        //Camera.main.GetComponent<SmoothFollow>().target = PlayerPibot.transform;

        //Debug.Log("카메라야 카메라야 잘들어왔느뇨>?");
        camSetting();

        //치트키 h키 누르면 바로 도시.
        if (Input.GetKey(KeyCode.H))
        {

            SceneManager.LoadScene("city3");


           

        }
        //치트키 h키 누르면 바로 도시.
        //if (Input.GetKey(KeyCode.J))
        //{
        //    SceneManager.LoadScene("kidsroom");
        //}

        if (Input.GetKey(KeyCode.O))
        {
          //  GameObject.Destroy(gameObject);

            SceneManager.LoadScene("HappyEnding");

        }

        if (Input.GetKey(KeyCode.P))
        {
          //  GameObject.Destroy(gameObject);

            SceneManager.LoadScene("BadEnding");

        }

      
    }

    void FixedUpdate()
    {   //로컬 플레이어만 직접 위치와 회전 변경 가능
        if (!photonView.IsMine) //게임 오브젝트가 로컬 게임 오브젝트인 경우에만 이동, 회전, 애니메이션 파라미터 갱신 처리를 실행.
        {
            return;
        }

        //물리만 다루는 곳
        Jump();

        Move();

        Rope(upRope, noGravity);

        playerAnimator.SetFloat("VerticalMove", playerInput.Verticalmove);
        playerAnimator.SetFloat("HorizontalMove", playerInput.Horizontalmove);
        playerAnimator.SetBool("Grounded", isGrounded);
        playerAnimator.SetBool("upRope", isRope);
        playerAnimator.SetBool("UseGun", isUseGun);


    }
    private void OnParticleCollision(GameObject other)
    {
        if (other.transform.tag == "pushObject")
        {

            pusheffect.Play();



        }
        


    }
    // 입력값에 따라 캐릭터를 앞뒤로 움직임
    private void Move()
    {
        if (!photonView.IsMine) //게임 오브젝트가 로컬 게임 오브젝트인 경우에만 이동, 회전, 애니메이션 파라미터 갱신 처리를 실행.
        {
            return;
        }

    
            if (playerInput.Verticalmove != 0)
            {
                if (playerInput.Verticalmove == 1f)
                {
                    moveSpeed = startmoveSpeed + 5;
                }
                else
                {
                    moveSpeed = startmoveSpeed;
                }
            }

            Vector3 VertiacalmoveDistance =
                playerInput.Verticalmove * transform.forward * moveSpeed * Time.deltaTime;
            Vector3 HorizontalmoveDistance =
                playerInput.Horizontalmove * transform.right * moveSpeed * Time.deltaTime;
            //위치 변경
            playerRigidbody.MovePosition(playerRigidbody.position + VertiacalmoveDistance + HorizontalmoveDistance);
            // Vector3.up 축을 기준으로 rotSpeed만큼의 속도로 회전
            playerTranform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime * playerInput.mouseX);
        }
    

    private void Jump()
    {

        if (playerInput.jump && jumpcount < 2)
        {
            jumpcount++;
            playerRigidbody.velocity = Vector3.zero;
            if (jumpcount == 1)
            {
                playerRigidbody.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
            }
            else { playerRigidbody.AddForce(Vector3.up * jumpPower, ForceMode.Impulse); }

            isGrounded = false;

        }
    }
    private void camSetting()
    {

        isForwardcam = false;
        if (playerInput.rightmouse)
        {
            rightmouseCnt += 1;
            isUseGun = true;
            playershooter.enabled = true;
            playerpunch.enabled = false;//펀치 불가
            if (rightmouseCnt >= 2)//한번 더 누르면
            {
                playershooter.enabled = false;
                playerpunch.enabled = true; //펀치가능
                isUseGun = false;
                rightmouseCnt = 0;
            }
        }
        if (isUseGun) // 오른쪽마우스 누르면 총화면
        {
            isForwardcam = false;
            isGunViewcam = true;

            if (playerInput.backMirror) //F누르면 백미러 
            {
                isForwardcam = true;
            }
        }


        if (playerInput.backMirror) //백미러일때 
        {
            FollowCam.SetActive(false);
            ForwardCam.SetActive(true);

        }

        else if (!playerInput.backMirror) //백미러 아닐때 
        {
            if (!isUseGun) //총사용 안할때
            {
                FollowCam.SetActive(true);
                FirstPlayerCam.SetActive(false);
            }
            else if (isUseGun) //총사용 할때 
            {
                FirstPlayerCam.SetActive(true);
                FollowCam.SetActive(false);
            }
            ForwardCam.SetActive(false);
        }
    }

    private void CanUseGun()
    {
        rightmouseCnt += 1;
        isUseGun = true;
        playershooter.enabled = true;
        playerpunch.enabled = false;//펀치 불가
    }
    public void NotUseGun()
    {
        playershooter.enabled = false;
        playerpunch.enabled = true; //펀치가능
        isUseGun = false;
        rightmouseCnt = 0;
    }
    private void Rope(bool uprope, bool nogravity)
    {



    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.contacts[0].normal.y > 0.7)
        {
            jumpcount = 0;
            isGrounded = true;

        }

        if (collision.gameObject.tag == "rope")
        {
            //업로프가 false일때만 들어와라
            if (!upRope)
            {
                upRope = true;
                this.transform.Translate(0, 0.3f, 0);
            }
        }


    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject == rope)
        {
            upRope = false;
            isRope = false;


        }


    }
    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("노그래비티존");
        if (other.gameObject == ropeCollision)
        {
            noGravity = true;
        }

    }

}
