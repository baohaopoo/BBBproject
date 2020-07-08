using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StatusController : MonoBehaviour
{


    public static StatusController instance;
    private GameObject hp100;
    private GameObject hp80;
    private GameObject hp60;
    private GameObject hp40;
    private GameObject hp20;


    public int starthp=100;
    public int currentHP;

    void Start()
    {

        instance = this;
        currentHP = starthp;
 
    }


    void getdemage()
    {
        currentHP -= 20;
        hearthImage(currentHP);
    }

    void hearthImage(int HP)
    {
        if (HP==100)
        {
            hp100.SetActive(true);
        }
        else if (HP == 80)
        {
            hp100.SetActive(false);
            hp80.SetActive(true);
        }
    }

}
