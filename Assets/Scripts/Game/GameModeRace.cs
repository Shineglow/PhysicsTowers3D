using System.Collections.Generic;
using UnityEngine;

public class GameModeRace : GameMode
{
    

    protected override void Init()
    {
        zones = new List<TriggerZone>();
        var killZone = new GameObject();
        killZone.transform.SetPositionAndRotation(Vector3.zero, Quaternion.identity);
        zones.Add(killZone.AddComponent<KillZone>());
        var TopZone = new GameObject();
        TopZone.transform.SetPositionAndRotation(Vector3.zero, Quaternion.identity);
        var lineZone = TopZone.AddComponent<TopLineZone>();
        zones.Add(lineZone);
        lineZone.OnZoneStay += timer.StartTimer;
    }
}