using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Clock
{
    // 時計データクラス
    public class ClockDate
    {
        public DateTime BaseTime;
        public uint AdditionTime = new();
        public AdditionDate AdditionDate = new();
    }

    // 時計の時間調整用クラス
    public class AdditionDate
    {
        public uint AdditionSecond = 0;
        public uint AdditionMinute = 0;
        public uint AdditionHour = 0;
    }
}
