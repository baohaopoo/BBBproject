using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
public class applynickname : MonoBehaviourPunCallbacks
{
    public string userID = "baohao";

    public TMP_Text username;
    // Start is called before the first frame update
    void Start()
    {
        apply();
    }
    public void apply()
    {
        username.text = PlayerPrefs.GetString("USER_ID", "User_" + Random.Range(1, 999));
        // username.text = PlayerPrefs.GetString("USER_ID", "baohao");
        Debug.Log("여긴 안들어오는거니?");
    }
    // Update is called once per frame
    void Update()
    {
        PhotonNetwork.NickName = username.text;
        PlayerPrefs.SetString("USER_ID", PhotonNetwork.NickName);

    }
}
