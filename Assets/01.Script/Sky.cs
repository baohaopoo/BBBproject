using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sky : MonoBehaviour
{
    public bool inNight = true;

    private Material originalSky; //원래하늘 
    public Material NightSky; 
    public Material DaySky;

    void Start()
    {
        originalSky = RenderSettings.skybox;
    }

    // Update is called once per frame
    void Update()
    {
       if (inNight)
        {
            RenderSettings.skybox = NightSky;
        }
        else if (!inNight)
        {
            RenderSettings.skybox = DaySky;
        }
    }


    
}
