using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public GameObject player;

    public float offsetX = -400f;
    public float offsetY = 400f;
    public float offsetZ = 0f;
    Vector3 cameraPosition;

    //Zoom 관련
    public Transform ZoomTarget;
    public float Zoom;
    private Transform tr;
       
    //회전 관련
    public float rotateSpeed = 10f;



    // Start is called before the first frame update
    void Start()
    {

        tr = GetComponent<Transform>();






}

    // Update is called once per frame
    void Update()
    {
        //ZoomInOut(); 
    }
    private void LateUpdate()
    {

        cameraPosition.x = player.transform.position.x + offsetX;
        cameraPosition.y = player.transform.position.y + offsetY;
        cameraPosition.z = player.transform.position.z + offsetZ;

        transform.position = cameraPosition;

        ZoomInOut();
    }
    private void ZoomInOut()
    {

        Vector3 TargetDist = tr.position - ZoomTarget.position;
        TargetDist = Vector3.Normalize(TargetDist);

        tr.position -= (TargetDist * Input.GetAxis("Mouse ScrollWheel") * Zoom);
    
    
    }
}
