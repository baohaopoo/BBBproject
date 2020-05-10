using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StartButtonPressed : MonoBehaviour
{
    // Start is called before the first frame update

    void PressedStartButton()
    {

        SceneManager.LoadScene("city");
    
    }
}
