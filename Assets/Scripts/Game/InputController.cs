using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InputController : MonoBehaviour
{
    public Action<bool> OnPause;

    public GameObject block;
    public GameObject Block
    {
        set
        {
            block = value;
            movementOperations = value.GetComponent<BlockMovementOperations>();
            coliderScaler = value.GetComponent<ColiderScaler>();
        }
    }

    BlockMovementOperations movementOperations;
    ColiderScaler coliderScaler;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            movementOperations.HorizontalMove(-1);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            movementOperations.HorizontalMove(1);
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            movementOperations.HorizontalMove(-1, HorizontalMoveType.Full);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            movementOperations.HorizontalMove(1, HorizontalMoveType.Full);
        }


        if (Input.GetKeyDown(KeyCode.W))
        {
            movementOperations.Rotate();
            coliderScaler.UpdateScaleOnRotate();
        }

        if (Input.GetKey(KeyCode.S))
            movementOperations.FallFaster();
        else
            movementOperations.FallSlower();

        if (Input.GetKey(KeyCode.Space))
            OnPause?.Invoke(true);
    }
}
