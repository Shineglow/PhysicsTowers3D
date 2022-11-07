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
    public GameState GameState { get; private set; } = GameState.Start;
    public EndGameCondition EndGameCondition { get; private set; } = EndGameCondition.None;

    [SerializeField] protected GameController gameController;
    [SerializeField] protected List<TriggerZone> zones;
    [SerializeField] protected UITimer timer;

    protected abstract void Init();
}
