using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;

public class ChangeScenePoint : MonoBehaviourPunCallbacks
{
    public GameObject player;
    Scene scene2 = SceneManager.GetSceneByName("city3");


    // Start is called before the first frame update
    void Start()
    {
      

    }

    // Update is called once per frame


    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag== "Player")
        {

            SceneChange();
        
        
        }
    }

    private void SceneChange()
    {
        SceneManager.LoadScene("city3");

        //SceneManager.LoadScene("city3",LoadSceneMode.Additive);
        //SceneManager.MoveGameObjectToScene(player, scene2);
       
        
       // PhotonNetwork.LeaveRoom();
        

    }
}
