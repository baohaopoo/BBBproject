using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
 
public class Timelinedirector : MonoBehaviour
{


    // Update is called once per frame
    void Update()
    {
        if (GetComponent<PlayableDirector>().state != PlayState.Playing)
        {
            gameObject.SetActive(false);
        }
    }
}
