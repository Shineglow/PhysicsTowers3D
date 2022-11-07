using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TopLine : MonoBehaviour
{
    public Action OnCollisionBlockStay;

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.GetComponent<Rigidbody>().velocity.magnitude == 0)
            OnCollisionBlockStay?.Invoke();
    }
}
