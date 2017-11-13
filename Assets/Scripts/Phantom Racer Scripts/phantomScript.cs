﻿using UnityEngine;
using UnityEngine.SceneManagement;
using Xander.Debugging;
public class phantomScript : MonoBehaviour
{
    private ScoreManager.scoreStruct scoreInfo;
    private int currentPos = 0;
    private void Start()
    {
        int level = SceneManager.GetActiveScene().buildIndex;
        GameManager gameManager = GameManager.instance;
        switch (GameManager.instance.gameMode.currentMode)
        {
            case GameModes.Continuous:
                ScoreManager.continuousScores[] contScores = gameManager.scoreScript.topContinuousScores;
                for (int i = 0; i < contScores.Length; i++)
                {
                    if (contScores[i].difficulty == gameManager.gameDifficulty.currentDifficulty)
                    {
                        scoreInfo = contScores[i].levels[level];
                        break;
                    }
                }
                break;
            case GameModes.Cursed:
                ScoreManager.levelCurseScores[] levelScores = gameManager.scoreScript.topCurseScores;
                for (int i = 0; i < levelScores[level].curseScores.Length; i++)
                {
                    if (levelScores[level].curseScores[i].difficulty == gameManager.gameDifficulty.currentDifficulty)
                    {
                        scoreInfo = levelScores[level].curseScores[i];
                        break;
                    }
                }
                break;
            case GameModes.Free:
                break;
            case GameModes.Race:
                Debug.Log("To add, Race Case PhantomScript");
                break;
            default:
                Debug.LogWarning("Missing case: \"" + gameManager.gameMode.currentMode.ToString("F") + "\"" + this.Info(), this);
                break;
        }
    }
    void FixedUpdate()
    {
        if (null != scoreInfo.positions)
        {
            transform.position = scoreInfo.positions[currentPos];
            transform.rotation = scoreInfo.rotations[currentPos];
            ++currentPos;
            if (currentPos >= scoreInfo.positions.Length)
                currentPos = 0;
        }
    }
}