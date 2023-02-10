using UnityEngine;

public class SnappingHolder : Holder
{
    public GameObject snapParent;
    private Transform originalParent;

    protected override void Start()
    {
        base.Start();

        if (snapParent == null)
        {
            Debug.LogWarning("SnappingHolder nie ma ustawionego snapParent przez co bedzie dzialal jak zwykly holder");
        }

        originalParent = gameObject.transform.parent;
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        var collisionObject = collision.gameObject;
        
        if (collisionObject == snapParent)
        {
            transform.SetParent(collisionObject.transform);
        }
    }

    private void OnCollisionExit(Collision other)
    {
        var collisionObject = other.gameObject;
        
        if (collisionObject == snapParent)
        {
            transform.SetParent(originalParent);
        }
    }
}