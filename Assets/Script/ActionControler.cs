using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionControler : MonoBehaviour
{


    [SerializeField] //지역변수 인스펙터창에서만 수정가능
    private float range; // 상호작용 가능한 물체와 나의 거리 

    private bool OpenActivated = false; //열수 있을 때 true

    public static bool IsOpen;//열렸나요



    private RaycastHit hitInfo; //충돌체 정보 저장

    //문 레이어에만 반응하도록 레이어 마스크 설정
    [SerializeField]
    private LayerMask layerMask;

    //필요한 컴포넌트
    [SerializeField]
    private Text actionText;

    private void Start()
    {

    }
    void Update()
    {
        CheckDoor();

    }

    private void CanOpen()
    {
        if (OpenActivated)
        {
            if (hitInfo.transform != null)
            {
                InfoDisappear();
            }
        }
    }
    private void CheckDoor() //문에 닿았는지 체크
    {
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward),
            out hitInfo, range, layerMask))
        {
            if (hitInfo.transform.tag == "door")
            {
                InfoAppear();
            }
        }
        else
        {
            InfoDisappear();
        }
    }
    private void InfoAppear()
    {


        if (IsOpen == false)
        {
            OpenActivated = true;
            actionText.gameObject.SetActive(true);
            actionText.text = "열기" + "<color=red>" + "(E)" + "</color>";
            if (Input.GetKeyDown(KeyCode.E))
            {
                IsOpen = true;
                CheckDoor();
                CanOpen();
            }

        }
    }
    private void InfoDisappear()
    {
        OpenActivated = false;
        actionText.gameObject.SetActive(false);
    }
}
