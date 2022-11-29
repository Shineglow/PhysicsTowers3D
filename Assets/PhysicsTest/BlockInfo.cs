using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BlockInfo : MonoBehaviour
{
    [SerializeField]
    private BoxCollider[] _colliders = new BoxCollider[2];
    [SerializeField]
    private MeshFilter _mesh;
    [SerializeField]
    private Rigidbody _rb;

    public BoxCollider[] colliders { get { return _colliders; } private set { _colliders = value; } }
    public Mesh mesh { get { return _mesh.mesh; } private set { _mesh.mesh = value; } }
    public Rigidbody rb { get { return _rb; } private set { _rb = rb; } }
    public ScriptableBlock blockBaseInfo { get; private set; }



    public void Init(ScriptableBlock sb)
    {
        blockBaseInfo = sb;
        mesh = blockBaseInfo.Form;
        if(rb == null)
            rb = GetComponent<Rigidbody>();
        ConfigureColliders();
    }

    private void ConfigureColliders()
    {
        var colliderInfoStruct = blockBaseInfo.PhysicsBodys[0];
        ConfigureCollider(colliders[0], colliderInfoStruct.Size, colliderInfoStruct.Position);

        if (blockBaseInfo.PhysicsBodys.Length == 1)
            return;

        colliderInfoStruct = blockBaseInfo.PhysicsBodys[1];
        ConfigureCollider(colliders[1], colliderInfoStruct.Size, colliderInfoStruct.Position);
    }

    private void ConfigureCollider(BoxCollider collider, Vector3 size, Vector3 center)
    {
        collider.size = size;
        collider.center = center;
    }
}
