﻿using UnityEngine;
using TMPro;
public class DifficultyOptions : LevelMenuObjectGroup
{
    [SerializeField]
    private LevelMenuButton leftButton = null, rightButton = null;
    [SerializeField]
    private TextMeshPro difficultyText = null;
    new private void Start()
    {
        base.Start();
        if (null == leftButton)
            Debug.LogWarning("Missing DifficultyOptions.leftButton");
        if (null == rightButton)
            Debug.LogWarning("Missing DifficultyOptions.rightButton");
        if (null == difficultyText)
            Debug.LogWarning("Missing DifficultyOptions.difficultyText");
    }
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
    }
    private void ButtonRightFunction()
    {
    }
}