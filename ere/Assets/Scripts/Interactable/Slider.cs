using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slider : Slider<float> {
    protected override void LerpValToSend(float t)
    {
        valToSend = Mathf.Lerp(minVal, maxVal, t);
    }
}

public class Slider<T> : Holder<T>
{
    public GameObject minimumPos;
    public GameObject maximumPos;

    public float minVal=0, maxVal=1;    
    public override void Interact(Hand hand)
    {
        base.Interact(hand);
        transform.position = hand.transform.position + hand.GetForwardVector() * DISTANCE;

        //clamp to the positions
        ClampSlider();
        CalcVal();
        InteractTarget();
    }



    /// <summary>
    /// Magic of the internet, but it works NICE!    
    /// </summary>
    /// https://answers.unity.com/questions/568773/shortest-distance-from-a-point-to-a-vector.html
    private void ClampSlider()
    {
        //Get heading
        Vector3 heading = (maximumPos.transform.position - minimumPos.transform.position);
        float magnitudeMax = heading.magnitude;
        heading.Normalize();

        //Do projection from the point but clamp it
        Vector3 lhs = transform.position - minimumPos.transform.position;
        float dotP = Vector2.Dot(lhs, heading);
        dotP = Mathf.Clamp(dotP, 0f, magnitudeMax);
        this.transform.position = minimumPos.transform.position + heading * dotP;
    }

    private void CalcVal()
    {
        float distFromMin = minimumPos.transform.position.x - transform.position.x;
        float MaxDist = minimumPos.transform.position.x - maximumPos.transform.position.x;

        float div = distFromMin / MaxDist;


        LerpValToSend(div);        
    }

    /// <summary>
    /// t from 0 to 1
    /// </summary>
    /// <param name="t"></param>
    /// <returns></returns>
    virtual protected void LerpValToSend(float t)
    {
        //valToSend = Mathf.Lerp(minVal, maxVal, div);
    }

}
