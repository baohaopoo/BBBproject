using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

//inventory slot
public class Inventory : MonoBehaviourPun

{ 
    [SerializeField]
    private Gun gun;

    [SerializeField]
    private GameObject realTrap_item_prefab; //진짜덫 아이템

    [SerializeField]
    private GameObject realObstacle_item_prefab;// 송곳아이템

    [SerializeField]
    private GameObject player;

    public GameObject ham;
    public GameObject bread;
    //얘네는 내부적으로 다 들어와있어
    //private GameObject ham; //햄 아이템
    //private GameObject bread; //빵아이템

    private PlayerHaveItem playeritem;
    private ham hami;
    private bread bre;



    private void Start()
    {
        //ham = player.transform.Find("Ham").gameObject;
        //bread = player.transform.Find("Bread").gameObject;
        playeritem = GetComponent<PlayerHaveItem>();
        hami = GetComponent<ham>();
        bre = GetComponent<bread>();
    }
    private void Update()
    {

        if (playeritem.Iitem1 != null && Input.GetButtonDown("UseItem")) //아이템 있고 쉬프트키 누르면 사용 
        {
            Debug.Log("!!!!!!!!!!!!!!!!!!!?");
            checkItem(); //아이템 뭔지 체크
            playeritem.UseItem(); //아이템 지워주기 
  
        }

        //치트키********//
        if (Input.GetKey(KeyCode.Z))
        {
            UseBreadItem();
        }
        //*****************//

    }


    private void checkItem()
    {

        if (playeritem.Iitem1.name == "BulletItem")
        {
            Debug.Log("아이템 사용되고 있나?");
            UsebulletItem();

        }
        else if (playeritem.Iitem1.name == "TrapItem")
        {

            Debug.Log("아이템 사용되고 있나?");
            UsetrapItem();
        }

        //
        else if (playeritem.Iitem1.name == "ObstacleItem")
        {

            Debug.Log("아이템 사용되고 있나?");
            UseObstacleItem();
        }
        //
        else if (playeritem.Iitem1.name == "HamItem")
        {

            Debug.Log("햄 아이템 사용되고 있나?");
            UseHamItem();


        }
        else if (playeritem.Iitem1.name == "BreadItem")
        {

            Debug.Log("빵 아이템 사용되고 있나?");
            UseBreadItem();
        } 
    
    
    }

    private void UsebulletItem()
    {
    
            //gun에 
            gun.bulletRemain += 3;
            if (gun.bulletRemain > 5)
            {
                gun.bulletRemain = 5;
            }

            Debug.Log("지금 아이템 불렛을 추가했다! bullet:" + gun.bulletRemain);

            //추가하자마자 bulletUI가 갱신되어야함.
            gun.UpdateUI();
       
    }


    private void UsetrapItem()
    {
     
  

            //플레이어를 기준으로 조금 위, 조금 앞에 덫을 위치하게 한다.
            Vector3 pos = player.transform.position + Vector3.up * 0.4f + Vector3.forward * 2f;
            //바닥에 덫 생성
            PhotonNetwork.Instantiate(realTrap_item_prefab.name, pos, Quaternion.identity);
          
       

    }


    private void UseObstacleItem()
    {


            //플레이어를 기준으로 조금 위, 조금 앞에 obstacle을 위치하게 한다.
            Vector3 pos = player.transform.position + Vector3.up * 0.4f + Vector3.forward * 2f;
         
            PhotonNetwork.Instantiate(realObstacle_item_prefab.name, pos, Quaternion.identity);

        
       
    }
    [PunRPC]
    public void hamani()
    {

        ham.SetActive(true);
        player.GetComponent<Animator>().SetTrigger("isEat");

    }

    private void UseHamItem()
    {

        if (!photonView.IsMine)
        {
            return;
        }

        photonView.RPC("hamani", RpcTarget.All);

        //ham.SetActive(true);


        // photonView.PRC("RestoreHP",)

        //player.GetComponent<Health>().RestoreHP(80);


        player.GetComponent<Health>().HPrespawn();
       //UIManager.instance.UpdateHPSlider(100);
        //player.GetComponent<Health>().RestoreHP(80);

        //Health.instance.RestoreHP(80);


        //player.GetComponent<Health>().OnEnable();


    }

    [PunRPC]
    public void breadani()
    {

        bread.SetActive(true);
        player.GetComponent<Animator>().SetTrigger("isEat");

    }
    private void UseBreadItem()
    {
        if (!photonView.IsMine)
        {
            return;
        }

        photonView.RPC("breadani", RpcTarget.All);

        //현재 HP받아오자
        player.GetComponent<Health>().HPrespawn();
    

       // UIManager.instance.UpdateHPSlider(100);
        //Health.instance.RestoreHP(40);

        // player.GetComponent<Health>().RestoreHP(40);
        //player.GetComponent<Health>().OnEnable();



    
        //bread.SetActive(true);


        //if(PhotonNetwork.IsMasterClient)
        //player.GetComponent<Health>().RestoreHP(40);




    }




}
