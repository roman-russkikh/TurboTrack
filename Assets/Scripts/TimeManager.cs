using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI minutesText = null;

    [SerializeField]
    private TextMeshProUGUI secondsText = null;

    private int seconds = 0;
    private int minutes = 0;

    private float timer = 0;

    bool playing = false;

    // Start is called before the first frame update
    void Start()
    {
        playing = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!playing)
        {
            return;
        }

        timer += Time.deltaTime;
        int newMinutes = Mathf.FloorToInt(timer / 60);
        if (newMinutes != minutes)
        {
            minutes = newMinutes;
            UpdateText(minutesText, minutes);
        }
        int newSeconds = Mathf.FloorToInt(timer % 60);
        if (seconds != newSeconds)
        {
            seconds = newSeconds;
            UpdateText(secondsText, seconds);
        }

    }

    void UpdateText(TextMeshProUGUI text, int time)
    {
        string textToPrint = "";
        if (time / 10 == 0)
        {
            textToPrint = 0.ToString();
        }
        textToPrint += time.ToString();
        text.text = textToPrint;
    }
}
