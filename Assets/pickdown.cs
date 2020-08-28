using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickdown : MonoBehaviour
{

    public GameObject playerpick;
    // Start is called before the first frame update
    public void pickoff()
    { playerpick.gameObject.SetActive(false); }
}
