using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerController : MonoBehaviourPun
{
    public float moveSpeed = 5f;// 앞뒤 움직임 걷기속도 
    public float rotateSpeed = 180f; // 좌우 회전 속도
    public float jumpPower = 5f;

    private PlayerShooter playershooter; 
    private PlayerInput playerInput; // 플레이어 입력을 알려주는 컴포넌트
    private Rigidbody playerRigidbody; // 플레이어 캐릭터의 리지드바디
    private Animator playerAnimator; // 플레이어 캐릭터의 애니메이터
    public GameObject FollowCam;
    public GameObject ForwardCam;
    public GameObject FirstPlayerCam;
    public GameObject Timeline;

    bool isGrounded;
    bool isPicking;
    bool isRope;
    bool isForwardcam;
    bool isGunViewcam;
    public bool isUseGun;

    bool upRope;
    bool noGravity;
    int jumpcount = 0;



    GameObject PlayerGrabPoint; //플레이어 아이템 잡을 때 쓰는 객체변수 생성
    Collider col;
    GameObject rope; //플레이어 로프와 닿으면 수평이동 제한.
    GameObject ropeCollision;

    GameObject friend;

    //사다리
    GameObject Ladder;


    private bool isLadder;
    private bool isAir;
    public float speed = 3f;
    int rightmouseCnt = 0; //오른쪽마우스 두번누르면 1인칭시점 취소시키기위해 만든변수
    void Start()
    {
        playershooter = GetComponent<PlayerShooter>();
        playerInput = GetComponent<PlayerInput>();
        playerRigidbody = GetComponent<Rigidbody>();
        playerAnimator = GetComponent<Animator>();
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

        Debug.Log(isUseGun);

        camSetting();


    }

    void FixedUpdate()
    {

        //물리만 다루는 곳
        Jump();
        Rotate();
        Move();
        Rope(upRope, noGravity);

        playerAnimator.SetFloat("Move", playerInput.move);
        playerAnimator.SetFloat("Rotate", playerInput.rotate);
        playerAnimator.SetBool("Grounded", isGrounded);
        playerAnimator.SetBool("upRope", isRope);
        playerAnimator.SetBool("UseGun", isUseGun);


        ////로컬 플레이어만 직접 위치와 회전 변경 가능
        //if (!photonView.IsMine)
        //{
        //    return;
        //}

    }

    // 입력값에 따라 캐릭터를 앞뒤로 움직임
    private void Move()
    {
        Vector3 moveDistance =
            playerInput.move * transform.forward * moveSpeed * Time.deltaTime;
        //위치 변경
        playerRigidbody.MovePosition(playerRigidbody.position + moveDistance);
    }

    // 입력값에 따라 캐릭터를 좌우로 회전
    private void Rotate()
    {
        float turn = playerInput.rotate * rotateSpeed * Time.deltaTime;
        playerRigidbody.rotation =
            playerRigidbody.rotation * Quaternion.Euler(0, turn, 0f);

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
            if (rightmouseCnt >= 2)//한번 더 누르면
            {
                playershooter.enabled = false;
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
    private void Rope(bool uprope, bool nogravity)
    {
        Debug.Log("플레이어rope 들어옴");
        if (uprope)
        {
            Debug.Log("플레이어1차 충돌");
            Debug.Log("rope애니");
            isRope = true;

            bool upKey = Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W);
            bool downKey = Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S);


            if (upKey)
            {
                this.transform.Translate(0, 5f * Time.deltaTime, 0);

            }

            else if (downKey)
            {

                this.transform.Translate(0, -5f * Time.deltaTime, 0);

            }
        }



        else if (noGravity)
        {

            Debug.Log("노그래비티존");
            // playerRigidbody.isKinematic = true;
            bool upKey = Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W);
            bool downKey = Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S);

            if (upKey)
            {
                this.transform.Translate(0, 0, 3 * Time.deltaTime);
            }
            else if (downKey)
            {
                this.transform.Translate(0, 0, -3 * Time.deltaTime);
            }
        }



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

        //if (collision.gameObject == ropeCollision)
        //{
        //    nogravity = false;
        //}

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
