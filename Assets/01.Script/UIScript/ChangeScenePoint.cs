using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;


public class ChangeScenePoint : MonoBehaviourPunCallbacks
{

    //Scene scene2 = SceneManager.GetSceneByName("city3");
 

    // Start is called before the first frame update
    void Start()
    {
      

    }

    // Update is called once per frame


    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag== "Player")
        {

            UIManager.instance.playMovie();
            SceneChange();
        
        
        }
    }

    private void SceneChange()
    {


        SceneManager.LoadScene("city3");

    }
}
