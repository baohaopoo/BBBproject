using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

using Photon.Pun;
public class nicknameText : MonoBehaviourPun
{
    public TextMeshProUGUI nickname; //플레이어의 nickname을 데려와..
    private string name;

    //public TextMeshProUGUI nickname;
    Vector3 mypos;

    LobbyManager lobby;
    void Start()
    {
        nickname.text = "";
        name = PhotonNetwork.LocalPlayer.NickName;//lobby.inputplayer.text;
        nickname.text += name.ToString();


        
        mypos.x = 18.4f;
        mypos.y = 0;
        mypos.z = -10.3f;
    }

    // Update is called once per frame
    void Update()
    {
        //if (photonView.IsMine)
        //{

        //    nickname.transform.Rotate(-90, 0, 0);
        //    transform.position = mypos;

        
        //}
        
    }
}
