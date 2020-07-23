using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ItemBox : MonoBehaviour
{

    private bool IsOpen = false;

    private Animator BoxAnimator;


    private Transform ItemboxTransform;
    [SerializeField]
    private GameObject bullet_item_prefab; //총알 아이템
    [SerializeField]
    private GameObject trap_item_prefab; //덫 아이템
    [SerializeField]
    private GameObject obstacle_item_prefab; //가시 아이템
    [SerializeField]
    private GameObject ham_item_prefab; //햄 아이템

    public float SpawnTime = 300f; //아이템 스폰 시간 

    private float lastSpawnTime; //마지막 생성 시점

    private bool isFirstOpen;
    private void Start()
    {
        BoxAnimator = GetComponent<Animator>();
        ItemboxTransform = GetComponent<Transform>();

        lastSpawnTime = 0;
        isFirstOpen = true;
    }
    //박스 애니메이션 
    public void BoxAnimation()
    {
        if (IsOpen == false)
        {
            BoxAnimator.SetBool("BoxOpen", true);
            if (isFirstOpen) //처음으로 여는거면
            {
                Debug.Log("처음암");
                WhatItemIntheBox();
                isFirstOpen = false;
                lastSpawnTime = Time.time;
            }
            else //처음으로 여는게 아니면 
            {
                Debug.Log("처음아님");
                if (Time.time >= lastSpawnTime + SpawnTime) //쿨타임 돌고나서 가능 
                {
                    lastSpawnTime = Time.time;
                    WhatItemIntheBox();
                }
            }

            IsOpen = true;
        }
        else if (IsOpen == true)
        {
            BoxAnimator.SetBool("BoxOpen", false);
            IsOpen = false;
        }
    }

    //박스안에 아이템 랜덤 생성 
    private void WhatItemIntheBox()
    {
        Debug.Log("무얼까요무얼까요");
        int ItemNum = Random.Range(0, 4);//랜덤

        if (ItemNum == 0)
        {
            //총알 아이템 생성 Instantiate(생성아이템,아이템위치,기본회전값)
            Instantiate(bullet_item_prefab, ItemboxTransform.position, Quaternion.identity);

        }
        else if (ItemNum == 1)
        {
            //덫 아이템 생성
            Instantiate(trap_item_prefab, ItemboxTransform.position, Quaternion.identity);

        }

        else if (ItemNum == 2)
        {
            //가시아이템생성
            Instantiate(obstacle_item_prefab, ItemboxTransform.position, Quaternion.identity);
        }
        else if (ItemNum == 3)
        {
            //햄아이템생성
            Instantiate(ham_item_prefab, ItemboxTransform.position, Quaternion.identity);
        }

    }
}