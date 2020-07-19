using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Item_Action_Controller : MonoBehaviour
{
    [SerializeField]
    private float range;
    //습득 가능한 최대거리.
    private bool pickupActivated = false; //습득 가능할시 true


    private RaycastHit hitInfo; //충돌체 정보 저장

    //아이템 레이어에만 반응하도록 레이어 마스크 설정
    [SerializeField]
    private LayerMask layerMask;


    [SerializeField]

    private Text actionText;

    [SerializeField]
    private Inventory inventory;
    // Update is called once per frame
    void Update()
    {
        CheckItem();
        TryAction();

    }

    private void TryAction()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            CheckItem();
            CanPickUp();

        }

    }
    private void CanPickUp()
    {
        if (pickupActivated)
        {
            if (hitInfo.transform != null)
            {
                Debug.Log(hitInfo.transform.GetComponent<ItemPickup>().item.itemName + "획득");
                inventory.AcquireItem(hitInfo.transform.GetComponent<ItemPickup>().item);
                Destroy(hitInfo.transform.gameObject);
                DisappearInfo();
            }
        }

    }

    private void CheckItem()
    {

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hitInfo, range, layerMask))
        {

            if (hitInfo.transform.tag == "Item")

            {
                ItemInfoAppear();
            }
        }
        else
            DisappearInfo();
    }

    private void DisappearInfo()
    {
        pickupActivated = false;
        //actionText.gameObject.SetActive(false);

    }
    private void ItemInfoAppear()
    {
        pickupActivated = true;
        actionText.gameObject.SetActive(true);
        actionText.text = hitInfo.transform.GetComponent<ItemPickup>().item.itemName + " 획득하려면 (R)";


    }
}
