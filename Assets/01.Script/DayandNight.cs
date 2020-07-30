using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayandNight : MonoBehaviour
{
    [SerializeField]
    private float gameTime; 
     
    private bool isNight = false;

    void Update()
    {
        transform.Rotate(Vector3.right, 0.1f*gameTime * Time.deltaTime);
    }
}
