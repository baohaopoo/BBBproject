using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class inputField : MonoBehaviour
{
    public InputField inputfield;
    public static string fieldText;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        fieldText = inputfield.text;
        Debug.Log(fieldText);



    }
}
