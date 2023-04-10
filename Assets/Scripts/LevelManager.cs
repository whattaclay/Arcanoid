﻿using System;
using Configs;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private LevelsConfigs _levelsConfigs;
    [SerializeField] private GameStateManager _gameStateManager;

    private void Awake()
    {
        _gameStateManager.OnWin += SetCurrentLevelCompleted;
    }

    private void SetCurrentLevelCompleted()
    {
        var currentSceneName = SceneManager.GetActiveScene().name;
        foreach (var level in _levelsConfigs.Levels)
        {
            if (level.SceneName == currentSceneName)
            {
                level.Completed = true;
                return;
            }
        }
    }
}