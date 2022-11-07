using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FormApplyer : MonoBehaviour
{
    [SerializeField]
    private BoxCollider[] colliders;
    [SerializeField]
    private MeshFilter meshFilter;
    [SerializeField]
    private Rigidbody rb;

    public ScriptableBlock blockForm;
    public PhysicMaterial material;
    public float cellSize = .99f;

    public void ApplyForm(ScriptableBlock form)
    {
        blockForm = form;
        SetMesh();
        ConfigurateColliders();
        ConfigurateRigidbody();
    }

    private void ConfigurateColliders()
    {
        ConfigSingleCollider(0);
        if (blockForm.PhysicsBodys.Length == 1)
            colliders[1].gameObject.SetActive(false);
        else
            ConfigSingleCollider(1);
    }

    private void ConfigSingleCollider(int index)
    {
        colliders[index].size = blockForm.PhysicsBodys[index].Size * cellSize;
        colliders[index].center = blockForm.PhysicsBodys[index].Position * cellSize;
    }

    private void SetMesh()
    {
        meshFilter.mesh = blockForm.Form;
    }

    private void ConfigurateRigidbody()
    {
        rb.ResetCenterOfMass();
    }
}
