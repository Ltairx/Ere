using System.Collections;
using System.Collections.Generic;
using UnityEngine;


///zostawi³em na bool bo wajcha jako tako nie wysy³a innych danych niz fakt dzia³ania
public class Lever : Interactable<bool>
{
    public GameObject leverObject;//the which will be rotated
    public float rotationAngle = 30;//around x Axis
    public float rotatingTime = 1f;
    private bool On = false;
    private bool rotating = false;

    override protected void OnStartInteract(Hand hand)
    {
        if (!rotating)
        {
            //swap On state.
            On = !On;
            if (On)
            {
                valToSend = true;
                StartCoroutine(RotateLever(-rotationAngle));
            }
            else
            {
                valToSend = false;
                StartCoroutine(RotateLever(rotationAngle));
            }

            InteractTarget(); //czy mo¿e daæ to na koñcu korutyny, by dopiero po przejœciu dawa³o impuls?
        }
    }



    /// <summary>
    /// coroutine which will rotate lever in rotatinTime time
    /// </summary>
    /// <param name="angle"></param>
    /// <returns></returns>
    protected IEnumerator RotateLever(float angle)
    {
        rotating = true;//block interactions
        float startTime = Time.time;
        Vector3 startRot = leverObject.transform.localRotation.eulerAngles;
        float rotOffset = 0;
        while (Time.time < startTime + rotatingTime)
        {
            float t = (Time.time - startTime) / rotatingTime;
            rotOffset = Mathf.Lerp(0, angle, t);
            Vector3 tempRot = startRot;
            tempRot.x += rotOffset;
            leverObject.transform.localRotation = Quaternion.Euler(tempRot);
            yield return null;
        }
        startRot.x += angle;
        leverObject.transform.localRotation = Quaternion.Euler(startRot);
        rotating = false;
    }


}