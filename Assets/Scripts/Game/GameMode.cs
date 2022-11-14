using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum GameState
{
    Start,
    Play,
    Pause,
    Finish
}

public enum EndGameCondition
{
    None,
    Win,
    Lose
}

public abstract class GameMode : MonoBehaviour
{
    [SerializeField] protected GameController gameController;
    [SerializeField] protected List<TriggerZone> zones;
    [SerializeField] protected UITimer timer;

    public static float CellSize { private set; get; } = 2;
    public static float CameraHeighUnderBlocks { private set; get; } = 52;
}
