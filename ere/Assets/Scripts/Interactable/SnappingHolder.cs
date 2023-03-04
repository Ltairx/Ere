using System;
using UnityEngine;

public class SnappingHolder : Holder
{
    public GameObject snapParent;
    private Transform originalParent;
    public bool turnOffGravity;
    private Rigidbody rigidBody;
    private float snapParentWidth; 
    private float snapParentHeight; 
    private float snapParentDepth; 

    protected override void Start()
    {
        base.Start();

        if (snapParent == null)
        {
            Debug.LogWarning("SnappingHolder nie ma ustawionego snapParent przez co bedzie dzialal jak zwykly holder");
            return;
        }
        rigidBody = GetComponent<Rigidbody>();
        originalParent = gameObject.transform.parent;

        var renderer = snapParent.GetComponent<MeshRenderer>();
        var size = renderer.bounds.size;
        snapParentWidth = size.x / 2;
        snapParentHeight = size.y / 2;
        snapParentDepth = size.z / 2;
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        var collisionObject = collision.gameObject;

        if (collisionObject != snapParent) return;
        
        transform.SetParent(collisionObject.transform);

        if (turnOffGravity)
        {
            rigidBody.useGravity = false;

        }
    }

    private void OnCollisionExit(Collision other)
    {
        var collisionObject = other.gameObject;

        if (collisionObject != snapParent) return;
        
        transform.SetParent(originalParent);
        rigidBody.useGravity = true;
    }

    protected void LateUpdate()
    {
        if (!interactedLastFrame && transform.parent == snapParent.transform)
        {
            rigidBody.constraints = RigidbodyConstraints.FreezeAll;
        }
        else
        {
            rigidBody.constraints = RigidbodyConstraints.None;
        }
    }

    protected override void Move(Hand hand)
    {
        base.Move(hand);
        
        if (transform.localPosition.z > -snapParentDepth && transform.localPosition.z < snapParentDepth &&
            transform.localPosition.y > -snapParentHeight && transform.localPosition.y < snapParentHeight &&
            transform.localPosition.x > -snapParentWidth && transform.localPosition.x < snapParentWidth)
        {
            var localPosition = transform.localPosition;
            localPosition = new Vector3(localPosition.x, localPosition.y, -snapParentDepth);
            transform.localPosition = localPosition;
        }

    }
}