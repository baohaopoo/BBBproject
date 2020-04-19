using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;// 앞뒤 움직임 걷기속도 
    public float rotateSpeed = 180f; // 좌우 회전 속도
    public float jumpPower = 0f;

    private PlayerInput playerInput; // 플레이어 입력을 알려주는 컴포넌트
    private Rigidbody playerRigidbody; // 플레이어 캐릭터의 리지드바디
    private Animator playerAnimator; // 플레이어 캐릭터의 애니메이터

    bool isJumping=false;

    //int jumpcount = 0;

    // Start is called before the first frame update
    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        playerRigidbody = GetComponent<Rigidbody>();
        playerAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Jump"))
        {
            isJumping = true;
        }


        playerAnimator.SetFloat("Move", playerInput.move);
        playerAnimator.SetBool("Jump", isJumping);

    }

    void FixedUpdate()
    {
      //물리만 다루는 곳.;
        Jump();
        Rotate();
        Move();



    }

    // 입력값에 따라 캐릭터를 앞뒤로 움직임
    private void Move()
    {
        Vector3 moveDistance =
            playerInput.move * transform.forward * moveSpeed * Time.deltaTime;

        playerRigidbody.MovePosition(playerRigidbody.position + moveDistance);
    }

    // 입력값에 따라 캐릭터를 좌우로 회전
    private void Rotate()
    {
        float turn = playerInput.rotate * rotateSpeed * Time.deltaTime;
        playerRigidbody.rotation =
            playerRigidbody.rotation * Quaternion.Euler(0, turn, 0f);

    }

    void Jump()
    {
        if (!isJumping)
            return;

        playerRigidbody.MovePosition(transform.position + Vector3.up); //단순높이
        playerRigidbody.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);

        isJumping = false;
    
    
    }


}
