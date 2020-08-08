using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    [SerializeField]
    private Gun gun;

    [SerializeField]
    private GameObject realTrap_item_prefab; //진짜덫 아이템

    [SerializeField]
    private GameObject realObstacle_item_prefab;// 송곳아이템


    [SerializeField]
    private GameObject player;

    private GameObject ham;
    private GameObject bread;

    private PlayerHaveItem playeritem;

    private Animator playeranim;
    private Health playerhp;


    private void Start()
    {   
        ham = player.transform.Find("Ham").gameObject;
        bread= player.transform.Find("Bread").gameObject;
        playeritem = GetComponent<PlayerHaveItem>();
        playeranim = player.GetComponent<Animator>();
        playerhp = player.GetComponent<Health>();
    }
    private void Update()
    {

           
        if (playeritem.Iitem1 != null && Input.GetButtonDown("UseItem")) //아이템 있고 쉬프트키 누르면 사용 
        {
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
            UsebulletItem();
        }
        else if (playeritem.Iitem1.name == "TrapItem")
        {
            UsetrapItem();
        }
        else if (playeritem.Iitem1.name == "ObstacleItem")
        {
            UseObstacleItem();
        }
        else if (playeritem.Iitem1.name == "HamItem")
        {
            UseHamItem();
        }
        else if (playeritem.Iitem1.name == "BreadItem")
        {
            UseBreadItem();
        }
    }

    private void UsebulletItem()
    {        
        gun.bulletRemain += 3;
        if (gun.bulletRemain > 5)
        {
            gun.bulletRemain = 5;
        }
    }

    private void UsetrapItem()
    {
        //플레이어를 기준으로 조금 위, 조금 앞에 덫을 위치하게 한다.
        Vector3 pos = player.transform.position+ Vector3.up*0.4f+Vector3.forward*2f;
        //바닥에 덫 생성
        Instantiate(realTrap_item_prefab, pos, Quaternion.identity);

    }

    private void UseObstacleItem()
    {
        //플레이어를 기준으로 조금 위, 조금 앞에 덫을 위치하게 한다.
        Vector3 pos = player.transform.position + Vector3.up * 0.4f + Vector3.forward*2f;
        //바닥에 덫 생성
        Instantiate(realObstacle_item_prefab, pos, Quaternion.identity);
    }

    private void UseHamItem()
    {

        playeranim.SetTrigger("isEat");
        ham.SetActive(true);
        playerhp.RestoreHP(80);
    }

    private void UseBreadItem()
    {

        playeranim.SetTrigger("isEat");
        bread.SetActive(true);
        playerhp.RestoreHP(40);
    }



}
