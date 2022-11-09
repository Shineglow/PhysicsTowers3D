using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum HorizontalMoveType
{
    Full,
    Half
}

public class BlockMovementOperations : MonoBehaviour
{
    private Rigidbody rb;
    float fallSpeed, maxSpeed = -12, minSpeed = -6;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void HorizontalMove(float horizontalDirection, HorizontalMoveType moveType = HorizontalMoveType.Half)
    {
        switch (moveType)
        {
            case HorizontalMoveType.Full:
                rb.MovePosition(transform.position + Vector3.right * horizontalDirection * GameMode.CellSize);
                return;
            case HorizontalMoveType.Half:
                rb.MovePosition(transform.position + horizontalDirection * Vector3.right * GameMode.CellSize / 2);
                return;
        }
    }

    public void Rotate()
    {
        rb.MoveRotation(Quaternion.Euler(0, 0, transform.rotation.eulerAngles.z + 90f));
    }

    public void FallFaster()
    {
        fallSpeed = maxSpeed;
    }
    public void FallSlower()
    {
        fallSpeed = minSpeed;
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector3(0, fallSpeed, 0);
        //AlignBlock();
    }

    public void AlignBlock() 
    {
        transform.position = new Vector3(Mathf.Round(transform.position.x), transform.position.y, 0);
    }
}
