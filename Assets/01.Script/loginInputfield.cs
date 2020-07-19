using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using TMPro;


public class loginInputfield : MonoBehaviour
{
    public string userID = "baohao";

    public TMP_InputField userid;
    
    // Start is called before the first frame update
    void Start()
    {
        userid.text = PlayerPrefs.GetString("USER_ID", "User_" + Random.Range(1, 999));

    }

    public void OnLogin()
    {
        PhotonNetwork.NickName = userid.text;
        PlayerPrefs.SetString("USER_ID", PhotonNetwork.NickName);

        //userid.text = PlayerPrefs.GetString("USER_ID", "User_" + Random.Range(1, 999));

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
