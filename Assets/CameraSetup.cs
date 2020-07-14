using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine; //시네머신 코드

using Photon.Pun; //Pun관련 코드
public class CameraSetup : MonoBehaviourPun
{
    // Start is called before the first frame update
    void Start()
    {
        //만약 자신이 로컬 플레이어라면
        if (photonView.IsMine)
        {
            Debug.Log("과연 나는 무슨 카메라인가 true면 로컬 false면 리모트"+photonView.IsMine);
            //씬에 있는 가상 카메라를 찾고
            CinemachineVirtualCamera followCam = FindObjectOfType<CinemachineVirtualCamera>();
            //가상 카메라의 추적 대상을 자신의 트랜스폼으로 변경
            followCam.Follow = transform;
            followCam.LookAt = transform;

        
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
