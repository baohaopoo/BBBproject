using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Photon.Pun;
using Photon.Realtime;

using UnityEngine.UI;


public class PhotonConnectManager : MonoBehaviourPunCallbacks
{

    private string gameVersion = "1.0";

    public Text connectionMessage;
    public Button JoinButton;


    private void Awake()
    {

        PhotonNetwork.GameVersion = gameVersion;
        PhotonNetwork.ConnectUsingSettings();


        Debug.Log("1. 마스터 서버에 접속중입니다..");

        JoinButton.interactable = false;
        connectionMessage.text = "마스터 서버에 접속중이다 이놈아..";

    }


    //마스터 서버 접속 성공시 자동 실행 default lobby 로 들어감..
    public override void OnConnectedToMaster()
    {
        JoinButton.interactable = true;
        connectionMessage.text = "온라인 : 마스터 서버와 연결됨 이놈아";
        Debug.Log("2.온라인 : 마스터 서버와 연결되었습니다..");
    }

    //마스터 서버 접속 실패 시 자동 실행 
    public override void OnDisconnected(DisconnectCause cause)
    {
        JoinButton.interactable = false;
        connectionMessage.text = "오프라인 : 마스터 서버와 연결되지 않음 \n접속 재시도 중...";
        Debug.Log("오프라인: 마스터 서버와 연결되지 않고 있음.. 접속 재시도 중입니다..");
        PhotonNetwork.ConnectUsingSettings();

    }

    //룸 접속 시도 
    public void Connect() 
    {

        //중복 접속 시도를 막기 위해 접속 버튼 잠시 비활
        JoinButton.interactable = false;

        if (PhotonNetwork.IsConnected)
        {
            //룸 접속 실행
            connectionMessage.text = "방에 접속..";
            PhotonNetwork.JoinRandomRoom();
            Debug.Log("방에 접속..");
            


        }
    
    
    
    
    }
    void Start()
    {

        

    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
