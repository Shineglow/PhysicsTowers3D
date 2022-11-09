using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class ColiderScaler : MonoBehaviour
{
    [SerializeField]
    private ScriptableBlock scriptableBlock;
    [SerializeField]
    private BoxCollider[] colliders;
    public bool isHorizontal = true;

    [SerializeField]
    public float zRotation;
    [SerializeField]
    public int floatPartOfZRotation;

    //private void OnValidate()
    //{
    //    zRotation = (int)transform.rotation.eulerAngles.z;
    //    floatPartOfZRotation = (int)Mathf.Abs(zRotation % 180);
    //    if ((floatPartOfZRotation) == 0 || zRotation == 0)
    //        UpdateScale(scriptableBlock.PhysicsBodys, new Vector3(.4f, 0, 0));
    //    else
    //        UpdateScale(scriptableBlock.PhysicsBodys, new Vector3(0, .4f, 0));
    //}

    public void Init(ScriptableBlock sb)
    {
        scriptableBlock = sb;
        UpdateScale(scriptableBlock.PhysicsBodys, new Vector3(.4f, 0, 0));
    }

    public void UpdateScaleOnRotate()
    {
        zRotation = transform.rotation.eulerAngles.z;
        floatPartOfZRotation = Mathf.RoundToInt( Mathf.Abs(zRotation % 180));
        if (floatPartOfZRotation != 0)
            UpdateScale(scriptableBlock.PhysicsBodys, new Vector3(.4f, 0, 0));
        else
            UpdateScale(scriptableBlock.PhysicsBodys, new Vector3(0, .4f, 0));
    }

    public void ResetScale()
    {
        UpdateScale(scriptableBlock.PhysicsBodys, new Vector3());
    }

    private void UpdateScale(PositionAndSize[] collidersInfo, Vector3 substractionSize)
    {
        for (int i = 0; i < collidersInfo.Length; i++)
        {
            colliders[i].size = collidersInfo[i].Size * GameMode.CellSize - substractionSize;
        }
    }
}
