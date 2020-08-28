using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerpickup : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject playerpick;
    int cnt = 0;

    public void pick()
    {
        playerpick.gameObject.SetActive(true);
        cnt += 1;


        if (cnt == 2)
        {
            playerpick.gameObject.SetActive(false);
            cnt = 0;
          
        }
    }

    public void pickoff()
    {
        playerpick.gameObject.SetActive(false);
  
    }
}

