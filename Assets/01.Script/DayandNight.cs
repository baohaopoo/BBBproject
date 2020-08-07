using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayandNight : MonoBehaviour
{
    [SerializeField]
    private float gameTime=5; 
    private Transform SunTransform;
    private float rotX;
    private Sky skyimg;
    public float DayTime; //몇초에 한번씩 낮밤 바뀔지 (현실시간)
    private float lastTime; 
    private void Start()
    {
        SunTransform = GetComponent<Transform>();
        skyimg = GetComponent<Sky>();
        lastTime = Time.time;
        DayTime = 1800 / gameTime; 
    }
    void Update()
    {
        transform.Rotate(Vector3.right, 0.1f * gameTime * Time.deltaTime);

        rotX = SunTransform.rotation.x;


        // Debug.Log("rotX:"+rotX+",Time:"+(Time.time-lastTime));
        if (Time.time > lastTime + DayTime)
        {
            lastTime = Time.time;
            skyimg.inNight = !skyimg.inNight; //밤낮 바꾸기
            skyimg.progressDawn = 0;
            skyimg.progressDay = 0;
            skyimg.progressEvening = 0;
            skyimg.progressNight = 0;


        }


    }

}
