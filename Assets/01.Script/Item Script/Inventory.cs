﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Inventory : MonoBehaviourPun,IPunObservable
{

    //주기적으로 자동 실행
    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {


    }


    [SerializeField]
    private Slot slot1;
    [SerializeField]
    private Slot slot2;
    [SerializeField]
    private Gun gun;

    [SerializeField]
    private GameObject realTrap_item_prefab; //진짜덫 아이템

    [SerializeField]
    private GameObject realObstacle_item_prefab;// 송곳아이템

    [SerializeField]
    private GameObject player;

    //얘네는 내부적으로 다 들어와있어
    private GameObject ham; //햄 아이템
    private GameObject bread; //빵아이템

    private void Start()
    {
        ham = player.transform.Find("Ham").gameObject;
        bread = player.transform.Find("Bread").gameObject;
    }
    private void Update()
    {
        if (slot1.item != null && Input.GetButtonDown("UseItem")) //아이템 있고 쉬프트키 누르면 사용 
        {
          
            Debug.Log(slot1.item.name);
            checkItem();
            slot1.UseItem();

            if (slot2.item != null) //만약 두번째 슬롯 비어있지 않으면 , 첫번째 슬롯으로 아이템 이동 
            {
                AcquireItem(slot2.item);
                slot2.UseItem();
            }

        }

        //치트키//

        if (Input.GetKey(KeyCode.Z))
        {
            UseBreadItem();
        }
        //

    }


    private void checkItem()
    {

        if (slot1.item.name == "BulletItem")
        {
            Debug.Log("아이템 사용되고 있나?");
            photonView.RPC("UsebulletItem", RpcTarget.All);

           
        }
        else if (slot1.item.name == "TrapItem")
        {
            photonView.RPC("UsetrapItem", RpcTarget.All);
            Debug.Log("아이템 사용되고 있나?");
        }

        //
        else if (slot1.item.name == "ObstacleItem")
        {
            photonView.RPC("UseObstacleItem",RpcTarget.All);
            Debug.Log("아이템 사용되고 있나?");
        }
        //
        else if (slot1.item.name == "HamItem")
        {
            photonView.RPC("UseHamItem", RpcTarget.All);
            Debug.Log("햄 아이템 사용되고 있나?");
   
        }
        else if (slot1.item.name == "BreadItem")
        {
            photonView.RPC("UseBreadItem", RpcTarget.All);
            Debug.Log("빵 아이템 사용되고 있나?");
        }
    }

    [PunRPC]
    private void UsebulletItem()
    {
        if (photonView.IsMine)
        {
            //gun에 
            gun.bulletRemain += 3;
            if (gun.bulletRemain > 5)
            {
                gun.bulletRemain = 5;
            }

            Debug.Log("지금 아이템 불렛을 추가했다! bullet:" + gun.bulletRemain);
            //추가하자마자 bulletUI가 갱신되어야함.

            gun.BulletUI(gun.bulletRemain);
            gun.UpdateUI();
        }
     
    }

    [PunRPC]
    private void UsetrapItem()
    {

        if (photonView.IsMine)
        {

            //플레이어를 기준으로 조금 위, 조금 앞에 덫을 위치하게 한다.
            Vector3 pos = player.transform.position + Vector3.up * 0.4f + Vector3.forward * 2f;
            //바닥에 덫 생성
            Instantiate(realTrap_item_prefab, pos, Quaternion.identity);
           // PhotonNetwork.Instantiate(realTrap_item_prefab.name, pos, Quaternion.identity);

        }
       

    }

    [PunRPC]
    private void UseObstacleItem()
    {

        if (photonView.IsMine)
        {
            //플레이어를 기준으로 조금 위, 조금 앞에 obstacle을 위치하게 한다.
            Vector3 pos = player.transform.position + Vector3.up * 0.4f + Vector3.forward * 2f;
         
            Instantiate(realObstacle_item_prefab, pos, Quaternion.identity);

        }
       
    }

    [PunRPC]
    private void UseHamItem()
    {

        if (photonView.IsMine)
        {

            player.GetComponent<Animator>().SetTrigger("isEat");
            ham.SetActive(true);
            player.GetComponent<Health>().RestoreHP(80);


        }
       
    }
    [PunRPC]
    private void UseBreadItem()
    {
        if (photonView.IsMine)
        {

            player.GetComponent<Animator>().SetTrigger("isEat");
            bread.SetActive(true);
            player.GetComponent<Health>().RestoreHP(40);


        }
      
    }
    [PunRPC]
    public void AcquireItem(Item _item)
    {

        if (photonView.IsMine)
        {
            if (slot1.item == null) //슬롯 비어있으면 넣어줌
            {
                slot1.AddItem(_item);
            }
            else if (slot1.item != null) //슬롯 비어있으면 넣어줌
            {
                if (slot2.item == null)
                {
                    slot2.AddItem(_item);
                }

                else if (slot2.item != null)
                {
                    Debug.Log("슬롯이 꽉 찼습니다.");
                }
            }


        }

    }
     

}
