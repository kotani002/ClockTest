using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Clock;
using TMPro;

public class DigitalClock : MonoBehaviour
{
    //時間表示用テキスト
    [SerializeField]
    private TextMeshProUGUI _timeText = null;
    private void SetUp(ClockDate clockData)
    {
        ViewTime(clockData.BaseTime,clockData);
    }

    // デジタル時計表示
    public void ViewTime(DateTime time, ClockDate _clockData)
    {
        // 表示用時間の計算
        float hours = time.Hour + _clockData.AdditionDate.AdditionHour;
        float minutes = time.Minute + _clockData.AdditionDate.AdditionMinute;
        float seconds = time.Second + _clockData.AdditionTime + _clockData.AdditionDate.AdditionSecond;
        string meridiem = null;

        // 調整時間を追加した表示用時間の調整
        for (; seconds >= 60f; seconds -= 60f)
        {
            minutes += 1f;
        }
        for (; minutes >= 60f; minutes -= 60f)
        {
            hours += 1f;
        }
        if (hours >= 24f)
        {
            hours = -24;
        }
        if (hours < 12)
        {
            meridiem = "AM";
        }
        else
        {
            meridiem = "PM";
        }

        _timeText.text = $"{meridiem} {hours.ToString("00")}:{minutes.ToString("00")}:{seconds.ToString("00")}";
    }
}
