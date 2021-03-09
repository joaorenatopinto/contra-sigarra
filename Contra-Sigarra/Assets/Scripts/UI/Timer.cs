using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timerText;
    float time = 0f;

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        string minutes = System.Math.Floor(time / 60).ToString("00");
        string seconds = System.Math.Floor(time % 60).ToString("00");
        timerText.text = minutes + ":" + seconds;
    }
}
