using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField]
    private Slot slot1;
    [SerializeField]
    private Slot slot2;
    [SerializeField]
    private Gun gun;

    private void Update()
    {
        if (slot1.item != null && Input.GetButtonDown("UseItem"))
        {
            checkItem();
            slot1.UseItem();
        }

    }
    private void checkItem()
    {

        if (slot1.item.name == "BulletItem")
        {
            UsebulletItem();
        }
    }
    private void UsebulletItem()
    {
        
        gun.bulletRemain += 3;
        if (gun.bulletRemain > 5)
        {
            gun.bulletRemain = 5;
        }
        Debug.Log("@@@@bullet:" + gun.bulletRemain);
        gun.BulletUI(gun.bulletRemain);
    }

    public void AcquireItem(Item _item)
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
