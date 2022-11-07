using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class TriggerZone : MonoBehaviour
{
    public Action OnZoneStay;

    protected abstract void BlockAction(GameObject block);
    private void OnTriggerEnter(Collider other)
    {
        BlockAction(other.gameObject);
    }
}

public class KillZone : TriggerZone
{
    protected override void BlockAction(GameObject block)
    {
        Destroy(block);
        OnZoneStay?.Invoke();
    }
}

public class TopLineZone : TriggerZone
{
    public Action OnLineLeaveLastBlock;
    private Dictionary<GameObject, int> blocksOnLine;

    private void Start()
    {
        blocksOnLine = new Dictionary<GameObject, int>();
    }

    protected override void BlockAction(GameObject block)
    {
        if (blocksOnLine.ContainsKey(block))
            blocksOnLine[block]++;
        else
            blocksOnLine.Add(block,1);
        block.GetComponent<BlockCollisionHandler>().isBlockContact += OnZoneStay;
    }

    private void OnTriggerExit(Collider other)
    {
        if (blocksOnLine.ContainsKey(other.gameObject))
        {
            if (blocksOnLine[other.gameObject] == 0)
                blocksOnLine.Remove(other.gameObject);
            else
                blocksOnLine[other.gameObject]--; 
        }
        if (blocksOnLine.Count == 0)
            OnLineLeaveLastBlock?.Invoke();
    }
}
