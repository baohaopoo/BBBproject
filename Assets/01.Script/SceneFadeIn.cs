using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneFadeIn : MonoBehaviour
{

    public float FadeTime = 2f; //Fade 효과 재생시간

    Image fadeImage; //fadeImg 가져오기
    float start;
    float end;
    float time = 0;
    bool isPlaying = false; //한번만 fade in 하도록


    private void Awake()
    {
        fadeImage = GetComponent<Image>();

        fadein();
    }

    public void fadein()
    {
        isPlaying = true;
        Color fadecolor = fadeImage.color;
        time = 0f;
        //fadecolor.a = Mathf.Lerp(start, end, time);

        if (isPlaying) //한번만 쓰려고
        {
            while (fadecolor.a > 0f) //이미지 색상의 알파값이 0으로 가까워질수록 투명해짐.
            {

                time += Time.deltaTime / FadeTime; //지정한 시간만큼 효과를 주기 위해 1초를 나눠줌.
                fadecolor.a = Mathf.Lerp(start, end, time); //start와 end 중간값을 리턴.

                fadeImage.color = fadecolor;
               


            }


        }
    
    }
  

}
