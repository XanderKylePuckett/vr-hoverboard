﻿using UnityEngine;
using TMPro;
public class TimeOfDayOptions : LevelMenuObjectGroup
{
    [SerializeField]
    private LevelMenuButton leftButton = null, rightButton = null;
    [SerializeField]
    private TextMeshPro timeOfDayText = null;
    new private void Start()
    {
        base.Start();
        if (null == leftButton)
            Debug.LogWarning("Missing TimeOfDayOptions.leftButton");
        if (null == rightButton)
            Debug.LogWarning("Missing TimeOfDayOptions.rightButton");
        if (null == timeOfDayText)
            Debug.LogWarning("Missing TimeOfDayOptions.timeOfDayText");
    }
}