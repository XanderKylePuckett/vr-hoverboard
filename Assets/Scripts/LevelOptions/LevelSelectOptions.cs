﻿using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class LevelSelectOptions : LevelMenuObjectGroup
{
    [SerializeField]
    private LevelMenuButton leftButton = null, rightButton = null;
    [SerializeField]
    private TextMeshPro levelNameText = null;
    [SerializeField]
    private Image levelImage = null;
    [Space, Header("Level Images")]
    [SerializeField]
    private Sprite canyonImage = null;
    [SerializeField]
    private Sprite multiEnrironmentImage = null;
    [SerializeField]
    private Sprite backyardRacetrackImage = null;
    private enum Level { Canyon, MultiEnvironment, BackyardRacetrack, NumLevels }
    [SerializeField]
    private Level defaultLevel = Level.Canyon;
    private Level tempLevel;
    [SerializeField]
    private WorldPortalProperties portal = null;
    public const int LevelBuildOffset = 2; // build index of the first level
    new private void Start()
    {
        base.Start();
        if (null == leftButton)
            Debug.LogWarning("Missing LevelSelectOptions.leftButton");
        if (null == rightButton)
            Debug.LogWarning("Missing LevelSelectOptions.rightButton");
        if (null == levelNameText)
            Debug.LogWarning("Missing LevelSelectOptions.levelNameText");
        if (null == levelImage)
            Debug.LogWarning("Missing LevelSelectOptions.levelImage");
        if (null == canyonImage)
            Debug.LogWarning("Missing LevelSelectOptions.canyonImage");
        if (null == multiEnrironmentImage)
            Debug.LogWarning("Missing LevelSelectOptions.multiEnrironmentImage");
        if (null == backyardRacetrackImage)
            Debug.LogWarning("Missing LevelSelectOptions.backyardRacetrackImage");
        if (null == portal)
        {
            Debug.LogWarning("Missing LevelSelectOptions.portal.. Will attempt to find a world portal");
            try { portal = FindObjectOfType<WorldPortalText>().GetComponent<WorldPortalProperties>(); }
            catch { portal = FindObjectOfType<WorldPortalProperties>(); }
            if (null == portal)
                Debug.LogWarning("LevelSelectOptions cannot find portal");
        }
    }
    new private void OnEnable()
    {
        base.OnEnable();
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
        if (0 == tempLevel)
            tempLevel = Level.NumLevels - 1;
        else
            --tempLevel;
        UpdateDisplay();
    }
    private void ButtonRightFunction()
    {
        ++tempLevel;
        if (Level.NumLevels == tempLevel)
            tempLevel = 0;
        UpdateDisplay();
    }
    private void UpdateDisplay()
    {
        levelNameText.SetText(tempLevel.ToString());
        switch (tempLevel)
        {
            case Level.Canyon:
                levelImage.sprite = canyonImage;
                break;
            case Level.MultiEnvironment:
                levelImage.sprite = multiEnrironmentImage;
                break;
            case Level.BackyardRacetrack:
                levelImage.sprite = backyardRacetrackImage;
                break;
            default:
                Debug.LogWarning("Switch statement on Level enum tempLevel in LevelSelectOptions.cs is missing case for Level." + tempLevel.ToString());
                break;
        }
    }
    public override void ConfirmOptions()
    {
        base.ConfirmOptions();
        portal.SceneIndex = (int)tempLevel + LevelBuildOffset;
    }
    public override void DefaultOptions()
    {
        base.DefaultOptions();
        tempLevel = defaultLevel;
        UpdateDisplay();
    }
    public override void ResetOptions()
    {
        base.ResetOptions();
        tempLevel = (Level)(portal.SceneIndex - LevelBuildOffset);
        UpdateDisplay();
    }
}