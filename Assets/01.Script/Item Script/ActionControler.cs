using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class ActionControler : MonoBehaviourPun
{
    

    [SerializeField]
    private PlayerHaveItem playerhaveitem;
    private void Start()
    {

    }

    //닿았을때.
    private void OnTriggerStay(Collider other)
    {
        ////호스트만 닿고 먹을수 있는데. 이때 
        //if (!PhotonNetwork.IsMasterClient)
        //{
        //    return;
        //}


        
        if (other.tag == "Item")
        {
            if (photonView.IsMine)
            {
                UIManager.instance.onactiontxt();
                // actionText.text = other.transform.GetComponent<ItemPickup>().item.itemName + " 획득 " + "<color=yellow>" + "(E)" + "</color>";
                UIManager.instance.getitem(other.transform.GetComponent<ItemPickup>().item.itemName);  //E키를 누르면 먹을수 있다.


                if (Input.GetKeyDown(KeyCode.E))
                {

                if (other.transform != null) //정보를 가져왔을때
                    { 
                       Debug.Log(other.transform.GetComponent<ItemPickup>().item.itemName + " 획득했습니다");
                        //theInventory.AcquireItem(other.transform.GetComponent<ItemPickup>().item);
                        playerhaveitem.AcquireItem(other.transform.GetComponent<ItemPickup>().item); //아이템 장착
                       



                    }


                    //삭제해랏

                    PhotonNetwork.Destroy(other.transform.gameObject);
                    UIManager.instance.offactiontxt();




                }

            }
         
        }
        //&&photonView.IsSceneView
        if (other.tag == "CanOpen")
        {

            if (photonView.IsMine)
            {
                UIManager.instance.onopentxt();
                UIManager.instance.openitem(other.transform.GetComponent<ItemPickup>().item.itemName);
                // openText.text = other.transform.GetComponent<ItemPickup>().item.itemName + " 열기/닫기 " + "<color=yellow>" + "(Q)" + "</color>";
                if (Input.GetKeyDown(KeyCode.Q))
                {
                    Debug.Log("1@@@@@@@@@@@@");
                    //if (other.transform != null) //정보를 가져왔을때
                    //{
                    //    other.GetComponent<ItemBox>().goani();//아이템박스 열기닫기

                    //}
                    if (other.transform.GetComponent<ItemPickup>().item.itemName == "아이템박스")
                    {
                        other.GetComponent<ItemBox>().goani();//아이템박스 열기닫기
                    }
                    else if (other.transform.GetComponent<ItemPickup>().item.itemName == "옷장")
                    {
                        other.GetComponent<Open_Closet>().ClosetAnimation();//옷장 열기닫기 
                    }
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