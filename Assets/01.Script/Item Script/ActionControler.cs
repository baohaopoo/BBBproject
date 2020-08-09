﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionControler : MonoBehaviour
{

    [SerializeField]
    private PlayerHaveItem playerhaveitem;

    [SerializeField]
    private GameObject player;

    private Animator pickupanim;
    private Item item;
    public int FriendNum;
    private void Start()
    {
        pickupanim = player.GetComponent<Animator>();
        FriendNum = 0;

    }
    private void OnTriggerStay(Collider other)
    {
        

        if (other.tag == "Item")
        {
            item = other.transform.GetComponent<ItemPickup>().item;
            UIManager.instance.onactiontxt();
            UIManager.instance.getitem(item.itemName);  //E키를 누르면 먹을수 있다.

            if (Input.GetKeyDown(KeyCode.E))
            {
                if (other.transform != null) //정보를 가져왔을때
                {
                    pickupanim.SetTrigger("isPickup"); //플레이어 애니메이션
                    Debug.Log(item.itemName + " 획득했습니다");
                    playerhaveitem.AcquireItem(item); //아이템 장착
                    //Destroy(other.transform.gameObject); //아이템 파괴
                    other.transform.GetComponent<ItemDestroy>().destroyMe();
   
                }
                UIManager.instance.offactiontxt();
            }
        }

        if (other.tag == "CanOpen")
        {
            item = other.transform.GetComponent<ItemPickup>().item;
            UIManager.instance.onopentxt();
            UIManager.instance.openitem(item.itemName);

            if (Input.GetKeyDown(KeyCode.Q))
            {
                if (other.transform != null) //정보를 가져왔을때
                {
                    if (item.itemName == "아이템박스")
                    {
                        other.GetComponent<ItemBox>().BoxAnimation();//아이템박스 열기닫기
                    }
                    else if (item.itemName == "옷장")
                    {
                        other.GetComponent<Open_Closet>().ClosetAnimation();//옷장 열기닫기 
                    }

                }
            }      
        }
        if (other.tag == "Friend")
        {

            item = other.transform.GetComponent<ItemPickup>().item;
            UIManager.instance.onactiontxt();
            UIManager.instance.friendfind(item.itemName);  //E키를 누르면 먹을수 있다.
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (other.transform != null) //정보를 가져왔을때
                {
                    FriendNum += 1; ///////////////
                    UIManager.instance.getScore(FriendNum);
                    pickupanim.SetTrigger("isPickup"); //플레이어 애니메이션
                    if (item.itemName == "토끼")
                    {
                        Debug.Log("토깽쓰 ");
                    }
                    Destroy(other.transform.gameObject); //아이템 파괴
                }
                UIManager.instance.offactiontxt();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        UIManager.instance.offactiontxt();
        UIManager.instance.offopentxt();
    }




}