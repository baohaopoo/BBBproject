﻿using System.Collections;
using System.Collections.Generic;

using Photon.Pun; 
using Photon.Realtime; 

using UnityEngine;
using UnityEngine.UI;


public class LobbyManager : MonoBehaviourPunCallbacks
{
    private string gameVersion = "Kidsroom 1.0"; //게임 버전

    public Text connectionInfoText; 
    public Button joinButton; 



    //게임 실행과 동시에 마스터 서버 접속 시도
    void Start()
    {
        PhotonNetwork.GameVersion = gameVersion; //접속에 필요한 정보설정
        PhotonNetwork.ConnectUsingSettings(); //설정한 정보로 마스터 서버 접속 시도


        Debug.Log("마스터 서버에 접속중..");


        joinButton.interactable = false; //접속하는 동안에 룸 접속 못하도록 접속 버튼 비활.
        connectionInfoText.text = "마스터 서버에 접속중..";



    }

    //마스터 서버 접속 성공시 자동 실행
    public override void OnConnectedToMaster() {
        joinButton.interactable = true;
        connectionInfoText.text = "온라인 : 마스터 서버와 연결됨";
        Debug.Log("온라인 : 마스터 서버와 연결됨");


    }

    //마스터 서버 접속 실패시 자동 실행
    public override void OnDisconnected(DisconnectCause cause)
    {
        joinButton.interactable = false;
        connectionInfoText.text = "오프라인 : 마스터 서버와 연결되지 않음 \n접속 재시도 중...";
        Debug.Log("오프라인: 마스터 서버와 연결되지 않음 ,접속 재시도 중.");
        PhotonNetwork.ConnectUsingSettings();
    }

    //룸 접속 시도
    public void Connect() {
        //중복 접속 시도를 막기 위해 접속 버튼 잠시 비활성화
        joinButton.interactable = false;
        //마스터 서버에 접속중이라면
        if (PhotonNetwork.IsConnected)
        {
            //룸 접속 실행
            connectionInfoText.text = "룸에 접속...";
            PhotonNetwork.JoinRandomRoom();
            Debug.Log("룸에 접속..");
        }
        else
        {
            //마스터 서버에 접속 중이 아니라면 마스터 서버에 접속 시도
            connectionInfoText.text = "오프라인: 마스터 서버와 연결되지 않음 \n 접속 재시도중...";
            //마스터 서버로의 재접속 시도
            PhotonNetwork.ConnectUsingSettings();
        }
    }

    //빈방이 없어 랜덤 룸 참가에 실패한 경우 자동 실행
    public override void OnJoinRandomFailed(short returnCode, string message) {
        Debug.Log("No Room");
        connectionInfoText.text = "빈 방이 없음.. 새로운 방 생성..";
        PhotonNetwork.CreateRoom(null, new RoomOptions { MaxPlayers = 4 });

    }



    //룸에 참가 완료된 경우 자동 실행
    public override void OnJoinedRoom()
    {
        connectionInfoText.text = "방 참가 성공";
        Debug.Log("Joined room");
        PhotonNetwork.LoadLevel("Kidsroom"); //모든 룸 참가자가 Kidsroom씬을 로드하게 함.

  




    }

  
}
