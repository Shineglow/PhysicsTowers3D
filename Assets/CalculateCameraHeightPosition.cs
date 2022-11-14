using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEditor.PackageManager;
using UnityEngine;

public class CalculateCameraHeightPosition : MonoBehaviour
{
    [SerializeField]
    private Camera _camera;
    public float upperLimit, lowerLimit;
    [SerializeField]
    public float delta, minDelta = 1f, maxDelta = 3f;
    public float direction = 0;

    private void DynamicChangeDelta(float deltaDistance)
    {
        var scaler = deltaDistance / 10;
        if(scaler > 1)
            scaler = 1;
        delta = (maxDelta - minDelta) * scaler;
    }

    private void Start()
    {
        StartCoroutine(CameraVerticalMove());
        StartCoroutine(Move());
    }

    IEnumerator CameraVerticalMove()
    {
        while (true)
        {
            direction = CalculateDistanceToBlocks();
            yield return new WaitForSeconds(.5f);
        }
    }

    IEnumerator Move()
    {
        while (true)
        {
            if(direction != 0)
                MoveThisWithCamera();
            yield return null;
        }
    }

    private void MoveThisWithCamera()
    {
        var deltaPosition = Vector3.up * direction * delta * Time.deltaTime;
        _camera.transform.position += deltaPosition;
    }

    private int CalculateDistanceToBlocks()
    {
        var minimalDistance = -1;
        float deltaDistance = 0;
        for(var i = -10; i <= 10; i += 2)
        {
            var rayStartPosition = new Vector3(i, transform.position.y, 0);
            var r = new Ray(rayStartPosition, Vector3.down);

            if (Physics.Raycast(r, out RaycastHit hitInfo, 1000))
            {
                deltaDistance = lowerLimit - hitInfo.distance;
                if (hitInfo.distance < upperLimit)
                {
                    DynamicChangeDelta(Mathf.Abs(hitInfo.distance - upperLimit));
                    return 1;
                }
                if (!(hitInfo.distance > lowerLimit))
                    minimalDistance = 0;
            }
        }

        DynamicChangeDelta(Mathf.Abs(deltaDistance));
        return minimalDistance;
    }
}
