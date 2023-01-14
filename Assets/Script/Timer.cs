using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    // Start is called before the first frame update

    public Slider timerSlider;
    public TextMeshProUGUI timerText;
    public float gameTime;

    public TextMeshProUGUI scoreText;

    private bool stopTimer;

    float timer = 00f;

    void Start()
    {
        stopTimer = false;
        timerSlider.maxValue = gameTime;
        timerSlider.value = gameTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (scoreText.text != "0")
        {
            timer += Time.deltaTime;
            float time = gameTime - timer;

            int minutes = Mathf.FloorToInt(time / 60);
            int seconds = Mathf.FloorToInt(time - minutes * 60f);

            string textTime = string.Format("{00}", seconds);

            

            if (time <= 0)
            {
                stopTimer = true;
                SceneManager.LoadScene(2); 
            }

            if (stopTimer == false)
            {
                timerText.text = textTime;
                timerSlider.value = time;
            }
        }
    }

}
