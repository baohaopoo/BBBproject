using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Utility;

public class CameraBlocker : MonoBehaviour
{
    private GameObject maincam;
    private SmoothFollow smoothfollow;
    private MainCameraController maincamcontroller;
    private float camWidth= 8.0f;
    private float camHeight = 4.0f;
    private float camDistance = 0f;// 타겟으로부터 카메라까지 거리
    Vector3 camDir;
    Vector3 dir;
    private int wallcnt = 0;
    void Start()
    {
        maincam = GameObject.FindGameObjectWithTag("MainCamera");
        smoothfollow = maincam.GetComponent<SmoothFollow>();
        maincamcontroller = maincam.GetComponent<MainCameraController>();
        camWidth = -smoothfollow.width;
        camHeight = smoothfollow.height;

        camDistance = Mathf.Sqrt(camWidth * camWidth + camHeight * camHeight);
        //카메라리그에서 카메라위치까지의 방향벡터
        dir = new Vector3(0, camHeight, camWidth).normalized;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 rayTarget = transform.up * camHeight + transform.forward * camWidth;
        RaycastHit hitinfo;
        Physics.Raycast(transform.position, rayTarget, out hitinfo, camDistance);
        if (hitinfo.point != Vector3.zero && hitinfo.collider.tag == "wall")
        {
            Debug.Log("이것은 벽!!");
            wallcnt += 1;


        }
        else
        {
            wallcnt = 0;
            smoothfollow.inWall = false;
            maincamcontroller.iswall = false;
        }

        if ( wallcnt == 1)
        {
            smoothfollow.inWall = true;
            maincamcontroller.iswall = true;
            maincam.transform.position = hitinfo.point;
            maincam.transform.Translate(dir  * 3f);
        }
    }
}
