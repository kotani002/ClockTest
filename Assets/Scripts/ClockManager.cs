using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Clock;

public class ClockManager : MonoBehaviour
{
    // デジタル時計用のデータ
    private ClockDate _clockData = null;
    [SerializeField]
    private DigitalClock _digitalClock = null;
    [SerializeField]
    private AnalogClock _analogClock = null;
    //経過時間計測
    private float _additionCount = 0f;
    private bool _isDigital = true;

    // Start is called before the first frame update
    void Start()
    {
        SetUp();
    }

    void Update()
    {
        if (_additionCount >= 1f)
        {
            _additionCount -= 1f;
            _clockData.AdditionTime += 1;
            _digitalClock.ViewTime(_clockData.BaseTime, _clockData);
        }
        _analogClock.ViewTime(_clockData.BaseTime, _clockData);
        _additionCount += Time.deltaTime;
    }

    private void SetUp()
    {
        _clockData = new ClockDate();
        _clockData.BaseTime = DateTime.Now;
        _digitalClock.ViewTime(_clockData.BaseTime, _clockData);
        _analogClock.NowTimeSet(_clockData.BaseTime, _clockData);
    }

    public void ChangeClock()
    {
        _isDigital = !_isDigital;
        _digitalClock.gameObject.SetActive(_isDigital);
        _analogClock.gameObject.SetActive(!_isDigital);
        _analogClock.NowTimeSet(_clockData.BaseTime, _clockData);
    }

    public void OnClickAddHour()
    {
        _clockData.AdditionDate.AdditionHour += 1;
    }
    public void OnClickAddMinute()
    {
        _clockData.AdditionDate.AdditionMinute += 1;
    }
    public void OnClickAddSecond()
    {
        _clockData.AdditionDate.AdditionSecond += 1;
    }
}
