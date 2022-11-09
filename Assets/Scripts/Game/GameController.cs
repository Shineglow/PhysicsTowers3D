using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameController : MonoBehaviour
{
    public Action BlockHasBeenSpawned;
    public Action BlockHasBeenDestroyed;
    public Action<bool> OnPause;

    [SerializeField] private Spawner spawner;
    [SerializeField] private InputController inputController;
    [SerializeField] private GameMode gameMode;

    [SerializeField] private float spawnerDefaultHeught;

    private void Start()
    {
        var deathLine = new GameObject("DeathLine").AddComponent<DeathLine>();
        deathLine.transform.position -= new Vector3(0, 5, 0);
        CreateNewBlock();
    }

    private void CreateNewBlock()
    {
        var block = spawner.Spawn();
        inputController.Block = block;
        block.GetComponent<BlockCollisionHandler>().isBlockContact += CreateNewBlock;
        BlockHasBeenSpawned?.Invoke();
    }
}
