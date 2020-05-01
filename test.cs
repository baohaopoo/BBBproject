using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    GameObject playerGrabPoint;
    bool istrigger;
    // Start is called before the first frame update
    void Start()
    {
        playerGrabPoint = GameObject.FindGameObjectWithTag("grabPoint"); //플레이어 아이템 잡을 부분 객체 소환

    }

    // Update is called once per frame
    void Update()
    {
       

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == playerGrabPoint)
        {
            Debug.Log("enter Player");
            //isPlayerEnter = false;

            transform.SetParent(playerGrabPoint.transform); //아이템을 GrabPoint에 종속시키는 부분.
            transform.localPosition = Vector3.zero;
            transform.rotation = new Quaternion(0, 0, 0, 0);


        }
    }
}
