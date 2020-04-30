using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Doll_Action : MonoBehaviour
{

    GameObject player;
    GameObject playerGrabPoint;
    GameObject UIImage;
    AudioSource audioSource;
    Vector3 movement;
    bool isPlayerEnter;


    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        UIImage = GameObject.FindGameObjectWithTag("UIImage");
        audioSource = GetComponent<AudioSource>();

    }
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        audioSource.Play();

        
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

   

        }
        



 
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player) {
            isPlayerEnter = false;

        }
    }
}
