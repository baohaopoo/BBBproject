using System.Collections;
using System.Collections.Generic;

using Cinemachine;
using Photon.Pun; //포톤 
using Photon.Realtime; //포톤 서비스관련 라이브러리

using UnityEngine;

public class CameraSetup : MonoBehaviourPun
{
    // Start is called before the first frame update
    void Start()
    {
        //만약 자신이 로컬플레이어라면

        if (photonView.IsMine)  //IsMine프로퍼티는 해당 PhotonVeiw 컴포넌트가 추가되어 있는 게임 오브젝트의 소유권이 로컬 클라에 있는지 알려줌.
        {
            //씬에 있는 가상 카메라를 찾고
            CinemachineVirtualCamera followcam = FindObjectOfType<CinemachineVirtualCamera>();
            //가상 카메라의 추적 대상을 자신의 트랜스폼으로 변경
            followcam.Follow = transform;
            followcam.LookAt = transform;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
