using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using DG.Tweening;
using Clock;

public class AnalogClock : MonoBehaviour
{
    [SerializeField]
    private GameObject _hour;
    [SerializeField]
    private GameObject _minute;
    [SerializeField]
    private GameObject _second;
    private Quaternion quaternion;
    float timeCount = 0f;

    // アナログ時計表示
    public void ViewTime(DateTime time, ClockDate _clockData)
    {
        // 表示用時間の計算
        float hours = time.Hour + _clockData.AdditionDate.AdditionHour;
        float minutes = time.Minute + _clockData.AdditionDate.AdditionMinute;
        float seconds = time.Second + _clockData.AdditionTime + _clockData.AdditionDate.AdditionSecond;

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
            hours -= 24;
        }

        float hourAngle = hours * 360f / 12f;
        float minuteAngle = minutes * 360f / 60f;
        float secondAngle = seconds * 360f / 60f;

        _hour.transform.rotation = Quaternion.Lerp(_hour.transform.rotation,Quaternion.Euler(0f, 0f, -hourAngle),Time.deltaTime);
        _minute.transform.rotation = Quaternion.Lerp(_minute.transform.rotation,Quaternion.Euler(0f, 0f, -minuteAngle),Time.deltaTime);
        _second.transform.rotation = Quaternion.Lerp(_second.transform.rotation,Quaternion.Euler(0f, 0f, -secondAngle),Time.deltaTime);
    }

    // 現在時刻にリセット
    public void NowTimeSet(DateTime time, ClockDate _clockData)
    {
        float hours = time.Hour + _clockData.AdditionDate.AdditionHour;
        float minutes = time.Minute + _clockData.AdditionDate.AdditionMinute;
        float seconds = time.Second + _clockData.AdditionTime + _clockData.AdditionDate.AdditionSecond;

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
            hours -= 24;
        }

        float hourAngle = hours * 360f / 12f;
        float minuteAngle = minutes * 360f / 60f;
        float secondAngle = seconds * 360f / 60f;

        _hour.transform.DORotateQuaternion(Quaternion.Euler(0f, 0f, -hourAngle),1f);
        _minute.transform.DORotateQuaternion(Quaternion.Euler(0f, 0f, -minuteAngle),1f);
        _second.transform.DORotateQuaternion(Quaternion.Euler(0f, 0f, -secondAngle),1f);
    }
}
