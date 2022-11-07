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

    [SerializeField] private Rigidbody rb;

    private Dictionary<GameObject, SpringJoint> joints = new Dictionary<GameObject, SpringJoint>();
    private Dictionary<GameObject, SpringJoint> jointsAddedOnDelay = new Dictionary<GameObject, SpringJoint>();

    private void Start()
    {
        onCollisionEnterFunction += FirstContact;
        isBlockContact += scaler.ResetScale;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (joints.TryGetValue(collision.gameObject, out SpringJoint joint))
        {
            if (joint != null)
            {
                UpdateJointInfo(joint, collision);
                return;
            }
            else
                joints.Remove(collision.gameObject);
        }
        StartCoroutine(JointCreationDelay());
    }

    private void OnCollisionStay(Collision collision)
    {
        if (isCanCreateJoint)
            CreateNewJoint(collision);
    }

    private void OnJointBreak(float breakForce)
    {
        StartCoroutine(JointCreationDelay());
    }

    bool isCanCreateJoint = true;
    IEnumerator JointCreationDelay()
    {
        while (rb.velocity.magnitude > .02f)
            yield return null;
        isCanCreateJoint = true;
    }

    private void CreateNewJoint(Collision collision)
    {
        isCanCreateJoint = false;
        if (joints.ContainsKey(collision.gameObject))
            joints[collision.gameObject] = gameObject.AddComponent<SpringJoint>();
        else
            joints.Add(collision.gameObject, gameObject.AddComponent<SpringJoint>());
        onCollisionEnterFunction?.Invoke(collision);
    }

    private void UpdateJointInfo(SpringJoint joint, Collision collision)
    {
        var anchorPlusTwo = joint.anchor + Vector3.one * 3;
        var anchorMinusTwo = joint.anchor - Vector3.one * 3;

        var collisionMiddlePoint = new Vector3();
        foreach (var i in collision.contacts)
            collisionMiddlePoint += i.point;
        collisionMiddlePoint /= collision.contacts.Length;

        if (isVectorPartsHigher(anchorPlusTwo, collisionMiddlePoint) && isVectorsPartsLower(anchorMinusTwo, collisionMiddlePoint))
            return;

        joint.anchor = joint.connectedAnchor = collisionMiddlePoint;
    }

    private bool isVectorsPartsLower(Vector3 a, Vector3 b)
    {
        return a.x > b.x && a.y > b.y && a.z > b.z;
    }

    private bool isVectorPartsHigher(Vector3 a, Vector3 b)
    {
        return a.x < b.x && a.y < b.y && a.z < b.z;
    }

    private void FirstContact(Collision otherCollision)
    {
        onCollisionEnterFunction = SecondContact;    
        SecondContact(otherCollision);
        isBlockContact?.Invoke();
        Destroy(GetComponent<BlockMovementOperations>());
        Destroy(scaler);
    }

    private void SecondContact(Collision otherCollision)
    {
        var joint = gameObject.AddComponent<SpringJoint>();
        joint.autoConfigureConnectedAnchor = false;
        joint.connectedBody = otherCollision.rigidbody;
        joint.spring = 20f;
        joint.breakForce = 1f;
        joint.breakTorque = .05f;
        joint.enableCollision = true;

        var anchorPosition = new Vector3();
        foreach (var i in otherCollision.contacts)
            anchorPosition += i.point;
        anchorPosition /= otherCollision.contacts.Length;
        joint.anchor = joint.connectedAnchor = anchorPosition;
    }
}
