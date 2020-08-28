using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendManager : MonoBehaviour
{

    public int kidsroomFriend = 2;
    public int cityFriend = 3;

    private GameObject blue;
    private GameObject rabbit;
    private GameObject yellow;
    private GameObject pan;
    private GameObject pink;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void EndGame()
    {
        if (kidsroomFriend + cityFriend != 0)
        {
            return;
        }

        Debug.Log("게임끝!");
    }
    public void updateKidsFriend(int n)
    {
        if (kidsroomFriend == 2)
        {
            rabbit = GameObject.Find("rabbit");
            blue = GameObject.Find("blueBear");
        }
        kidsroomFriend += n;
        if (kidsroomFriend < 0)
        {
            kidsroomFriend = 0;
        }

        EndGame();


    }

    public void updateCityFriend(int n)
    {
        if (cityFriend == 3)
        {
            pink = GameObject.Find("pinkBear");
            pan = GameObject.Find("pandda");
            yellow = GameObject.Find("yellowBear");
        }
        cityFriend += n;
        if (cityFriend < 0)
        {
            cityFriend = 0;
        }

        EndGame();
    }

    public void respawnKidsroomFriend()
    {     

        if (!rabbit.activeSelf)
        {
            //토끼가 꺼져있으면 
            rabbit.SetActive(true);
            return;
        }
        else if (!blue.activeSelf)
        {
            //파란애가 꺼져있으면 
            blue.SetActive(true);
            return;
        }

    }
    public void respawnCityFriend()
    {


        if (!pink.activeSelf)
        {
            pink.SetActive(true);
            return;
        }
        else if (!pan.activeSelf)
        {
            pan.SetActive(true);
            return;
        }

        else if (!yellow.activeSelf)
        {
            yellow.SetActive(true);
            return;
        }

    }
}
