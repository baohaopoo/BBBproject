using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ItemBox : MonoBehaviour
{

    private bool IsOpen = false;

    private Animator BoxAnimator;

    [SerializeField]
    private GameObject Itembox_prefab;
    [SerializeField]
    private GameObject bullet_item_prefab; //총알 아이템

    private void Start()
    {
        BoxAnimator = GetComponent<Animator>();
    }
    //박스 애니메이션 
    public void BoxAnimation()
    {
        if (IsOpen == false)
        {
            BoxAnimator.SetBool("BoxOpen", true);
            WhatItemIntheBox();
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
        int ItemNum = Random.Range(0, 1);//랜덤

        if (ItemNum == 0)
        {
            //총알 아이템 생성 Instantiate(생성아이템,아이템위치,기본회전값)
            Instantiate(bullet_item_prefab, Itembox_prefab.transform.position, Quaternion.identity);

        }
    }
}
