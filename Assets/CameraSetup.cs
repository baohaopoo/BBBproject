using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using Photon.Pun;

public class CameraSetup : MonoBehaviourPun
{


    public Camera MainCam;
    // Start is called before the first frame update
    void Start()
    {
        if (photonView.IsMine)
        {
            //로컬이면
            MainCam = Camera.main;

        
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
