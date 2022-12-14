using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BlockCollisionHandler : MonoBehaviour
{
    public Action isBlockContact;
    private Action<Collision> onCollisionEnterFunction;

    [SerializeField]
    private ColiderScaler scaler;
    [SerializeField] 
    private Rigidbody rb;
    private Dictionary<GameObject, SpringJoint> joints = new Dictionary<GameObject, SpringJoint>();

    [SerializeField]
    private GameObject[] layerChangeObjects;

    private void Start()
    {
        onCollisionEnterFunction = FirstContact;
        isBlockContact += scaler.ResetScale;
    }

    private void OnCollisionEnter(Collision collision)
    {
        onCollisionEnterFunction?.Invoke(collision);
    }

    private void FirstContact(Collision otherCollision)
    {
        rb.velocity = new Vector3(rb.velocity.x, 0, 0);
        onCollisionEnterFunction = SecondContact;
        isBlockContact?.Invoke();
        Destroy(GetComponent<BlockMovementOperations>());
        Destroy(scaler);
        foreach(var i in layerChangeObjects)
            i.layer = 0;
        CreateNewJoint(otherCollision);
    }

    private void SecondContact(Collision collision)
    {
        if (rb.velocity.y > 0.01)
            return;
        if (joints.TryGetValue(collision.gameObject, out SpringJoint joint))
        {
            if (joint != null)
                return;
            joints.Remove(collision.gameObject);
        }
        joints.Add(collision.gameObject, CreateNewJoint(collision));
    }

    private SpringJoint CreateNewJoint(Collision otherCollision)
    {
        var joint = gameObject.AddComponent<SpringJoint>();

        joint.enableCollision = true;
        joint.connectedBody = otherCollision.rigidbody;
        joint.spring = 1000;
        joint.breakForce = 15;
        joint.breakTorque = 5;

        return joint;
    }
}
