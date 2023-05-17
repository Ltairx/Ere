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
    private bool snap = false;
    [field: SerializeField] private Camera camera;

    private Vector3 originalPosition; 
    private Quaternion originalRotation; 

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

        var parentCollider = snapParent.GetComponent<BoxCollider>();
        var size = parentCollider.size;
        snapParentWidth = size.x / 2;
        snapParentHeight = size.y / 2;
        snapParentDepth = size.z / 2;

        originalPosition = gameObject.transform.position;
        originalRotation = gameObject.transform.rotation;
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        var collisionObject = collision.gameObject;

        if (collisionObject != snapParent) return;
        
        transform.SetParent(collisionObject.transform);
        snap = true;
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
        snap = false;
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
        //var yRot = transform.rotation.y;
        var rotation = hand.transform.rotation;
        
        transform.LookAt(transform.position + rotation * Vector3.up, rotation * Vector3.back);
        transform.localRotation = transform.localRotation * Quaternion.Euler(0, 90, 0);

        
        base.Move(hand);
        
        if (snap && transform.localPosition.z > -snapParentDepth && transform.localPosition.z < snapParentDepth &&
            transform.localPosition.y > -snapParentHeight && transform.localPosition.y < snapParentHeight &&
            transform.localPosition.x > -snapParentWidth && transform.localPosition.x < snapParentWidth)
        {
            var localPosition = transform.localPosition;
            localPosition = new Vector3(localPosition.x, localPosition.y, 0);
            transform.localPosition = localPosition;
        }

    }

    public void ResetPosition()
    {
        gameObject.transform.position = originalPosition;
        gameObject.transform.rotation = originalRotation;
    }
}