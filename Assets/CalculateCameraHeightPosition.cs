using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class CalculateCameraHeightPosition : MonoBehaviour
{
    [SerializeField]
    private Camera _camera;
    private float targetCameraYPosition;
    [SerializeField]
    private float movementDelta = 1f;
    Coroutine cameraMove, raycaster;


    private void Awake()
    {
        targetCameraYPosition = _camera.transform.position.y;
        raycaster = StartCoroutine(RayCaster());
        cameraMove = StartCoroutine(MoveCamera());
    }

    private IEnumerator MoveCamera()
    {
        while(true)
        {
            var deltaVector = Vector3.up * movementDelta * Time.deltaTime;
            transform.position += deltaVector;
            _camera.transform.position += deltaVector;
            yield return null;
        }
    }

    private IEnumerator RayCaster()
    {
        while (true)
        {
            for(var i = -10; i <= 10; i+=4)
            {
                var r = new Ray(new Vector3(i, transform.position.y, 0), Vector3.down);

                if(Physics.Raycast(r, out RaycastHit hit, 1000f))
                {
                    if(hit.collider.gameObject.TryGetComponent(out BlockMovementOperations bmo))
                        continue;
                    if(hit.distance > GameMode.CameraHeighUnderBlocks+3)
                    {
                        targetCameraYPosition -= 3;
                        
                        yield return null;
                    }
                    if (hit.distance < GameMode.CameraHeighUnderBlocks - 3)
                    {
                        targetCameraYPosition += 3;
                        yield return null;
                    }
                }
            }

            yield return new WaitForSeconds(1);
        }
    }
}
