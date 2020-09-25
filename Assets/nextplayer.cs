using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class nextplayer : MonoBehaviour
{

    public void next()
    {
        //GameObject.Find("SSs").SetActive(false);
        GameObject.Find("PPs").SetActive(false);
        SceneManager.LoadScene("checkbearpick", LoadSceneMode.Additive);
        Debug.Log("체크베어 씬으로 가자");
    
    }

    public void prev()
    {
        GameObject.Find("PCs").SetActive(false);
        SceneManager.LoadScene("PlayerPick", LoadSceneMode.Additive);
        Debug.Log("brownbear씬으로 가자");

    }

    public void lovebear()
    {
        GameObject.Find("PCs").SetActive(false);
        SceneManager.LoadScene("pinkbearpick", LoadSceneMode.Additive);
        Debug.Log("핑크페버씬으로 가자");

    }

    public void prevlove()
    {
        //GameObject.Find("SSs").SetActive(false);
        GameObject.Find("PBs").SetActive(false);
        SceneManager.LoadScene("checkbearpick", LoadSceneMode.Additive);
        Debug.Log("체크베어 씬으로 가자");

    }
}
