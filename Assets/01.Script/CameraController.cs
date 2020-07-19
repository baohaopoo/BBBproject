using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

   
    //zoom 관련
    //public float zoomSpeed = 3f;

    public float rotateSpeed = 1;//화면이 움직이는 속도
    private float yaw = 0.0f;
    private float pitch = 0.0f;

    public Camera cam;
    public GameObject player;
    void Start()
    {



    }

    void Update()
    {
        //ZoomInOut();
        Rotate();
    }

    //private void ZoomInOut()
    //{

    //    float distance = Input.GetAxis("Mouse ScrollWheel") * -1 * zoomSpeed;
    //    if (distance != 0)
    //    {
    //        Cam.fieldOfView += distance;
    //    }
    //}
    void Rotate()
    {
        yaw += rotateSpeed * Input.GetAxis("Mouse X");
        pitch += rotateSpeed * Input.GetAxis("Mouse Y");;

        // Mathf.Clamp(x, 최소값, 최댓값) - x값을 최소,최대값 사이에서만 변하게 해줌
        pitch = Mathf.Clamp(pitch, -20f, 10f);
        cam.transform.localEulerAngles = new Vector3(-pitch, 0, 0.0f);
        player.transform.localEulerAngles = new Vector3(0, yaw, 0.0f);


    }
}
