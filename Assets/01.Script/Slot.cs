﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class Slot : MonoBehaviour, IPointerClickHandler
{

    public Item item; //획득한 아이템
    public int itemCount; //획득한 아이템 개수
    public Image itemImage; //아이템 이미지

    [SerializeField]
    private Text text_Count;
    [SerializeField]
    private GameObject go_CountImage; //활성화 이미지


    private Item theItemManager;

     private void start()
    {
        //하이라키에 있는 애
        theItemManager = FindObjectOfType<Item>();
    
    
    }
    //이미지 투명도 조절
    private void SetColor(float _alpha)
    {
        Color color = itemImage.color;
        color.a = _alpha;
        itemImage.color = color;
    
    }
    public void AddItem(Item _item, int _count = 1)
    {
        item = _item;
        itemCount = _count;
        itemImage.sprite = item.itemImage;


        if (item.itemType != Item.ItemType.Attack)
        {
            go_CountImage.SetActive(true);
            text_Count.text = itemCount.ToString(); //인티저 타입은 text와 호환안되기 때문에
        }

        else
        {
            text_Count.text = "0";
            go_CountImage.SetActive(false);
          
        }

        SetColor(1);

    
    }

    //아이템 갯수 조정
    public void SetSlotCount(int _count)
    {
        itemCount += _count;
        text_Count.text = itemCount.ToString();

        if (itemCount <= 0)
        {
            ClearSlot();
        }

    }

    //슬롯 초기화
    private void ClearSlot()
    {
        item = null;
        itemCount = 0;
        itemImage.sprite = null;
        SetColor(0);

     

        text_Count.text = "0";
        go_CountImage.SetActive(false);


    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {

            if (item != null)
            {
                if (item.itemType == Item.ItemType.Attack)
                {

                    //장착
                   // StartCoroutine(Item.)

                }

                else
                {
                    //소모
                    Debug.Log(item + "을 사용했습니다.");

                    SetSlotCount(-1);
                  
                }
            }

        
        }

    }

    
}
