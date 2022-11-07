using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Spawner : MonoBehaviour
{
    public Action OnBlockSpawn;

    [SerializeField] private GameObject blockPrefub;
    [SerializeField] private ScriptableBlock[] blocks;

    public GameObject Spawn()
    {
        var i = Instantiate(blockPrefub, transform.position, new Quaternion());
        var randomBlockIndex = UnityEngine.Random.Range(0, blocks.Length-1);
        i.GetComponent<FormApplyer>().ApplyForm(blocks[randomBlockIndex]);
        i.GetComponent<ColiderScaler>().Init(blocks[randomBlockIndex]);
        OnBlockSpawn?.Invoke();
        return i; 
    }
}
