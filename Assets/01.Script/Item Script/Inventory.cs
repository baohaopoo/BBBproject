using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField]
    private Slot slot1;
    [SerializeField]
    private Slot slot2;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

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
