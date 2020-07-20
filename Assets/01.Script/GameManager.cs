using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Photon.Pun;
using TMPro;

public class GameManager : MonoBehaviourPun
{

    public GameObject playerPrefab;

    
    
    
    //싱글톤 접근용 프로퍼티
    public static GameManager instance
    {
        get
        {
            // 만약 싱글톤 변수에 아직 오브젝트가 할당되지 않았다면
            if (m_instance == null)
            {
                // 씬에서 GameManager 오브젝트를 찾아 할당
                m_instance = FindObjectOfType<GameManager>();
            }

            // 싱글톤 오브젝트를 반환
            return m_instance;
        }
    }

    private static GameManager m_instance; // 싱글톤이 할당될 static 변수

    public bool isGameover { get; private set; } // 게임 오버 상태

    public GameObject gameoverUI;


   
    
    void Awake()
    {
        // 씬에 싱글톤 오브젝트가 된 다른 GameManager 오브젝트가 있다면
        if (instance != this)
        {
            // 자신을 파괴
            Destroy(gameObject);
        }
    }
    void Start()
    {
        isGameover = false;
        //playerPrefab.SetActive(true);

        Vector3 randomPos = Random.insideUnitSphere * 5f;

        
        PhotonNetwork.Instantiate(playerPrefab.name, randomPos, Quaternion.identity);

        Debug.Log(playerPrefab.name+"생성이다 이놈아ㅏ아앙");
    }
    
    void Update()
    {
        if (isGameover && Input.GetMouseButtonDown(0))
        {
            Restart();
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene("Kidsroom");
    }
    public void OnPlayerDead()
    {
        isGameover = true;
        gameoverUI.SetActive(true);
    }
}
