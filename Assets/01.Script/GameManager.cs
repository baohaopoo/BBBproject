using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;


public class GameManager : MonoBehaviourPunCallbacks//, IPunObservable
{

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


    public GameObject playerPrefab; //생성할 게임플레이어 



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
   
        Vector3 randomPos;

        randomPos.x = 88.2153f;
        randomPos.y = 4.39109f;
        randomPos.z = 453.567f;
 
        PhotonNetwork.Instantiate(playerPrefab.name, randomPos, Quaternion.identity);

       
        
    }

}
