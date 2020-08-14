using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Astar : MonoBehaviour
{
    public Transform StartPoint, EndPoint; //시작점과 끝점을 정해준다.
    private Grid grid;

    private void Awake()
    {


        grid = GameObject.Find("Grid").transform.GetComponent<Grid>();
    
    
    }

    void Update()
    {
        
    }
}
