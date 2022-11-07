using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DeathLine : MonoBehaviour
{
    public Action OnBlockDestroy;
    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
        OnBlockDestroy?.Invoke();
    }
}
