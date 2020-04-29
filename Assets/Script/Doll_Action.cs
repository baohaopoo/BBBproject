using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Doll_Action : MonoBehaviour
{

    GameObject player;
    GameObject playerGrabPoint;
    GameObject UIImage;
    Vector3 movement;
    bool isPlayerEnter;


    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerGrabPoint = GameObject.FindGameObjectWithTag("GrabPoint");
        UIImage = GameObject.FindGameObjectWithTag("UIImage");


    }
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("p") && isPlayerEnter) {
            transform.SetParent(playerGrabPoint.transform);
            transform.localPosition = Vector3.zero;
            transform.rotation = new Quaternion(0, 0, 0, 0);

            isPlayerEnter = false;

        
        }
        
    }
    public void Pickup(GameObject item)
    {
        SetGrab(item, true);
        
        //애니메이션 줍는 모션을 넣으면 됨.
       // Animator.SetTrigger("")

        //isPicking = truel
    
    
    }


    void Drop()
    {
        GameObject item = playerGrabPoint.GetComponentInChildren<Rigidbody>().gameObject;
        SetGrab(item, false);

        playerGrabPoint.transform.DetachChildren();
    
    
    }

    void SetGrab(GameObject item, bool isGrab)
    {
        Collider[] itemColliders = item.GetComponents<Collider>();
        Rigidbody itemRigidbody = item.GetComponent<Rigidbody>();

        foreach (Collider itemCollider in itemColliders) {
            itemCollider.enabled = !isGrab;

        }
        itemRigidbody.isKinematic = isGrab;

    
    
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player) {
            isPlayerEnter = true;

            //애니메이션을 위로 올라가는 애니메이션을 쓴다.


            //위로 올라가며 위에 자리를 잡는다.


            //movement.Set(0, 9, 0);
            //transform.position += movement;


            //친구 구하면 UI.
            if (Input.GetMouseButtonDown(0))
            {
                
                UIImage.gameObject.SetActive(true);
                Debug.Log("5번");
                Destroy(transform.gameObject);
                Debug.Log("친구 하나 구했다.");


            }



            //친구 하나 구할때마다 1씩 증가
            //Score_Manager.savedollNum += 1;




        }
        



 
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player) {
            isPlayerEnter = false;

        }
    }
}
