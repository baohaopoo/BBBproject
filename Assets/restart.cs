using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class restart : MonoBehaviour
{
    public UIManager ui_inst;
    public Health health;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnClickButton()
    {

        Debug.Log("restart버튼 고고링");
        //버튼이 눌러지면
        UIManager.instance.readyrespawn();
        
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
