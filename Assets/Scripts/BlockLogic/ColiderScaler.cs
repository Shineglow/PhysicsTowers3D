using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColiderScaler : MonoBehaviour
{
    [SerializeField]
    private ScriptableBlock scriptableBlock;
    [SerializeField]
    private BoxCollider[] colliders;
    [SerializeField]
    private float cellSize = 2f;

    public void Init(ScriptableBlock sb)
    {
        scriptableBlock = sb;
        UpdateScaleOnRotate();
    }

    public void UpdateScaleOnRotate()
    {
        var collidersInfo = scriptableBlock.PhysicsBodys;
        if((int)Mathf.Abs(transform.rotation.eulerAngles.z % 180) == 0)
            UpdateScale(collidersInfo, new Vector3(.4f, 0, 0));
        else
            UpdateScale(collidersInfo, new Vector3(0, .4f, 0));
    }

    public void ResetScale()
    {
        UpdateScale(scriptableBlock.PhysicsBodys, new Vector3());
    }

    private void UpdateScale(PositionAndSize[] collidersInfo, Vector3 substractionSize)
    {
        for (int i = 0; i < collidersInfo.Length; i ++)
        {
            colliders[i].size = collidersInfo[i].Size * cellSize - substractionSize;
        }
    }
}
