using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionControler : MonoBehaviour
{

    [SerializeField]
    private Text actionText;
    [SerializeField]
    private Text openText;

    [SerializeField]
    private Inventory theInventory;

    private void Start()
    {

    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Item")
        {
            actionText.gameObject.SetActive(true);
            actionText.text = other.transform.GetComponent<ItemPickup>().item.itemName + " 획득 " + "<color=yellow>" + "(E)" + "</color>";

            if (Input.GetKeyDown(KeyCode.E))
            {
                if (other.transform != null) //정보를 가져왔을때
                {
                    Debug.Log(other.transform.GetComponent<ItemPickup>().item.itemName + " 획득했습니다");
                    theInventory.AcquireItem(other.transform.GetComponent<ItemPickup>().item);
                    Destroy(other.transform.gameObject);
                    actionText.gameObject.SetActive(false);
                }
            }
        }

        if (other.tag == "CanOpen")
        {
            openText.gameObject.SetActive(true);
            openText.text = other.transform.GetComponent<ItemPickup>().item.itemName + " 열기/닫기 " + "<color=yellow>" + "(Q)" + "</color>";
            if (Input.GetKeyDown(KeyCode.Q))
            {
                if (other.transform != null) //정보를 가져왔을때
                {
                    other.GetComponent<ItemBox>().BoxAnimation();//아이템박스 열기닫기
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        actionText.gameObject.SetActive(false);
        openText.gameObject.SetActive(false);
    }




}