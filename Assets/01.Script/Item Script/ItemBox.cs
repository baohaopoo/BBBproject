using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBox : MonoBehaviour
{

    private bool IsOpen = false;

    private Animator BoxAnimator;

    
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

    }
}
