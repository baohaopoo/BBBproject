using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour
{

    public Item item; //획득한 아이템
    public Image itemImage; //아이템 이미지

    private Item theItemManager;

     private void start()
    {
        //하이라키에 있는 애
        theItemManager = FindObjectOfType<Item>();

        

    }

    //이미지 투명도 조절 (이미지 비어있을땐 투명하게 한다)
    public void SetColor(float _alpha)
    {
        Color color = itemImage.color;
        color.a = _alpha;
        itemImage.color = color; 
    }

    public void AddItem(Item _item)
    {
        item = _item;
        itemImage.sprite = item.itemImage; 

        SetColor(1); //아이템 보여준다.
    }

    public void UseItem()
    {
        item = null;
        itemImage.sprite = null;
        SetColor(0);
    }



}
