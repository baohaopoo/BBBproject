using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendManager : MonoBehaviour
{

    private int allFriend = 5;

    public GameObject blue;
    public GameObject rabbit;
    public GameObject yellow;
    public GameObject pan;
    public GameObject pink;

    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateFriend(int n)
    {
        //allFriend += n;
        //if (allFriend < 0)
        //{
        //    allFriend = 0;
        //}
    }

    public void respawnFriend()
    {
        if (!blue.activeSelf)
        {
            blue.SetActive(true);
        }
    }
}
