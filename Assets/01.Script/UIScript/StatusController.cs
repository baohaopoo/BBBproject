using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StatusController : MonoBehaviour
{

    [SerializeField]
    private int hp;
    private int currentHp;

    private Image[] image_Gauge;
    private const int Hp = 0;


    // Start is called before the first frame update
    void Start()
    {
        currentHp = hp;
       
        
    }

    // Update is called once per frame
    void Update()
    {
        GaugeUpdate();
    }

    private void GaugeUpdate()
    {
        image_Gauge[Hp].fillAmount = (float)currentHp / hp;
       
    }

}
