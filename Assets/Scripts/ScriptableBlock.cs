using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public struct PositionAndSize
{
    public Vector3 Position;
    public Vector3 Size;
}

[CreateAssetMenu(fileName ="BlockScriptable", menuName = "Blocks/BlockScriptable", order = 0)]
public class ScriptableBlock : ScriptableObject
{
    public Mesh Form;
    public Vector3 CenterOfMass;
    [SerializeField]public PositionAndSize[] PhysicsBodys;
}
