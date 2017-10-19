﻿using UnityEngine;
using TMPro;
public class TimeOfDayOptions : LevelMenuObjectGroup
{
    [SerializeField]
    private LevelMenuButton leftButton = null, rightButton = null;
    [SerializeField]
    private TextMeshPro timeOfDayText = null;
    private enum TimeOfDay { Noon, Afternoon, Evening, Midnight, Morning, NumTimesOfDay }
    [SerializeField]
    private TimeOfDay defaultTimeOfDay = TimeOfDay.Evening;
    private TimeOfDay tempTimeOfDay;
    private static TimeOfDay ActualTimeOfDay { get; set; } // replace with game's value
    private void OnEnable()
    {
        leftButton.OnButtonPressed += ButtonLeftFunction;
        rightButton.OnButtonPressed += ButtonRightFunction;
    }
    private void OnDisable()
    {
        leftButton.OnButtonPressed -= ButtonLeftFunction;
        rightButton.OnButtonPressed -= ButtonRightFunction;
    }
    private void ButtonLeftFunction()
    {
        if (0 == tempTimeOfDay)
            tempTimeOfDay = TimeOfDay.NumTimesOfDay - 1;
        else
            --tempTimeOfDay;
        UpdateDisplay();
    }
    private void ButtonRightFunction()
    {
        ++tempTimeOfDay;
        if (TimeOfDay.NumTimesOfDay == tempTimeOfDay)
            tempTimeOfDay = 0;
        UpdateDisplay();
    }
    private void UpdateDisplay()
    {
        switch (tempTimeOfDay)
        {
            case TimeOfDay.Noon:
                timeOfDayText.SetText("12:00 PM (Noon)");
                break;
            case TimeOfDay.Afternoon:
                timeOfDayText.SetText("4:20 PM (Afternoon)");
                break;
            case TimeOfDay.Evening:
                timeOfDayText.SetText("8:17 PM (Evening)");
                break;
            case TimeOfDay.Midnight:
                timeOfDayText.SetText("12:00 AM (Midnight)");
                break;
            case TimeOfDay.Morning:
                timeOfDayText.SetText("9:00 AM (Morning)");
                break;
            default:
                Debug.LogWarning("Switch statement on TimeOfDay enum tempTimeOfDay in TimeOfDayOptions.cs is missing case for TimeOfDay." + tempTimeOfDay.ToString());
                break;
        }
    }
    public override void ConfirmOptions()
    {
        base.ConfirmOptions();
        ActualTimeOfDay = tempTimeOfDay;
    }
    public override void DefaultOptions()
    {
        base.DefaultOptions();
        tempTimeOfDay = defaultTimeOfDay;
        UpdateDisplay();
    }
    public override void ResetOptions()
    {
        base.ResetOptions();
        tempTimeOfDay = ActualTimeOfDay;
        UpdateDisplay();
    }
}