using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;


// 플레이어 캐릭터를 조작하기 위한 사용자 입력을 감지
// 감지된 입력값을 다른 컴포넌트들이 사용할 수 있도록 제공
public class PlayerInput : MonoBehaviourPun
{
    public string moveAxisName = "Vertical"; 
    public string rotateAxisName = "Horizontal";
    public string jumpButtonName = "Jump"; 
    public string RightMouseButtonName = "UseGun"; //총사용할때 누르는 버튼
    public string fireButtonName = "Fire1"; //총 발사를 위한 버튼

    // 값 할당은 내부에서만 가능
    public float move { get; private set; } 
    public float rotate { get; private set; } 
    public bool jump { get; private set; }
    public bool rightmouse { get; private set; }
    public bool fire { get; private set; }
    public bool backMirror { get; private set; }


    // 매프레임 사용자 입력을 감지
    private void Update()
    {

        //로컬 플레이어가 아닌 경우 입력을 받지 않음
        if (!photonView.IsMine)
        {
            return;

        }


        ////게임오버 상태에서는 사용자 입력 감지 안함
        //if (GameManager.instance != null && GameManager.instance.isGameover)
        //{
        //    move = 0;
        //    rotate = 0;
        //    rightmouse = false;
        //    jump = false;
        //    fire = false;
        //    return;
        //}

        //  입력 감지
        move = Input.GetAxis(moveAxisName);
        rotate = Input.GetAxis(rotateAxisName);
        jump = Input.GetButtonDown(jumpButtonName);
        fire = Input.GetButtonDown(fireButtonName);

        //카메라 입력감지 
        backMirror = Input.GetKey(KeyCode.F);
        rightmouse = Input.GetButtonDown(RightMouseButtonName);


    }
}