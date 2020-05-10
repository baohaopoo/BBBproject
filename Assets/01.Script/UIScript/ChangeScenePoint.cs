using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScenePoint : MonoBehaviour
{

    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player =GameObject.FindGameObjectWithTag("Player");

    }

    // Update is called once per frame
    void Update()
    {


        
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == player)
        {

            SceneChange();
        
        
        }
    }

    private void SceneChange()
    {
        SceneManager.LoadScene("city3");
    
    
    }
}
