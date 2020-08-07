using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class ActionControler : MonoBehaviourPun
{
    

    [SerializeField]
    private PlayerHaveItem playerhaveitem;

    [SerializeField]
    private GameObject player;

    private Animator pickupanim;
    private Item item;


    private void Start()
    {
    
        //pickupanim = player.GetComponent<Animator>();
    }


    private void OnTriggerStay(Collider other)
    {


        if (other.tag == "Item")
        {

            if (photonView.IsMine) //로컬이라면,
            {
               
                item = other.transform.GetComponent<ItemPickup>().item;
                
                UIManager.instance.onactiontxt(); //UIManager로 actiontxt 켜줌
                UIManager.instance.getitem(other.transform.GetComponent<ItemPickup>().item.itemName);  //E키를 누르면 먹을수 있다.
         
                if (Input.GetKeyDown(KeyCode.E))
                {

                    if (other.transform != null) //정보를 가져왔을때
                    {

                        playerhaveitem.AcquireItem(other.transform.GetComponent<ItemPickup>().item); //아이템 장착

                    }

                     other.transform.GetComponent<ItemDestroy>().destroyall();
                    //Destroy(other.transform.gameObject);
                    UIManager.instance.offactiontxt();
          

                }

            }

        }


        if (other.tag == "CanOpen")
        {

            if (photonView.IsMine)
            {
           
                item = other.transform.GetComponent<ItemPickup>().item;
       
                UIManager.instance.onopentxt();
                UIManager.instance.openitem(other.transform.GetComponent<ItemPickup>().item.itemName);
                
                if (Input.GetKeyDown(KeyCode.Q))
                {
                    if (item.itemName == "아이템박스")
                    {
                        other.GetComponent<ItemBox>().goani();//아이템박스 열기닫기
                    }
                    else if (item.itemName == "옷장")
                    {
                        other.GetComponent<Open_Closet>().goclosetani();//옷장 열기닫기 
                    }
                }
            }
          
        }


        if (other.tag == "Friend")
        {

            if (photonView.IsMine) //로컬일때만, onactiontxt 켜져라.
            {

                //UIManager.instance.friendfind(other.transform.GetComponent<ItemPickup>().item.itemName);  
                //UIManager.instance.onactiontxt();

                item = other.transform.GetComponent<ItemPickup>().item;
                UIManager.instance.onactiontxt();
                UIManager.instance.friendfind(item.itemName);  //E키를 누르면 먹을수 있다.


                //E키를 누르면 먹어야하는데..
                if (Input.GetKeyDown(KeyCode.E))
                {


                    if (other.transform != null) //정보를 가져왔을때
                    {
                        // pickupanim.SetTrigger("isPickup"); //플레이어 애니메이션
                        if (item.itemName == "토끼")
                        {
                            //그저 이미지
                            UIManager.instance.updateFriend(1);

                        }

                    }
                    other.transform.GetComponent<ItemDestroy>().destroyall();
                    UIManager.instance.offactiontxt();
                }


            }
        }


    }

    private void OnTriggerExit(Collider other)
    {

        if (photonView.IsMine)
        {
            UIManager.instance.offactiontxt();
            UIManager.instance.offopentxt();
        }

    }




}