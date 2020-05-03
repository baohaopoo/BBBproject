using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Score_update : MonoBehaviour
{
    Text savedollsLabel;
    Image savedollsImage;

    // Start is called before the first frame update
    void Start()
    {
        //savedollsLabel = GetComponent<Text>();
        savedollsImage = GetComponent<Image>();
       // savedollsImage.gameObject.SetActive(false);
    }
     
    // Update is called once per frame
    void Update()
    {

        //if (Input.GetMouseButtonDown(0))
        //{
        //    savedollsImage.gameObject.SetActive(true);
        //    Debug.Log("5번");
        //    Destroy(transform.gameObject);
        //    Debug.Log("친구 하나 구했다.");


        //}
        //if (Score_Manager.EnableUI == false)
        //{
        //    // savedollsImage.gameObject.SetActive(false);
        //    savedollsImage.gameObject.SetActive(false);


        //}

        //else if (Score_Manager.EnableUI == true) {

        //    savedollsImage.gameObject.SetActive(true);
        //}
       
      
    }
}
