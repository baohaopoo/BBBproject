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

    private bool IsOpen = false;

    private Animator BoxAnimator;

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
                    Destroy(other.transform.gameObject);
                    actionText.gameObject.SetActive(false);
                }
            }
        }

        if (other.tag == "CanOpen")
        {
            openText.gameObject.SetActive(true);
            openText.text = other.transform.GetComponent<ItemPickup>().item.itemName + " 열기/닫기 " + "<color=yellow>" + "(Q)" + "</color>";
            BoxAnimator = other.GetComponent<Animator>();
            if (Input.GetKeyDown(KeyCode.Q))
            {
                if (other.transform != null) //정보를 가져왔을때
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
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        actionText.gameObject.SetActive(false);
        openText.gameObject.SetActive(false);
    }




}