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

        //clamp to the positions        

        ClampPos();

        CalcVal();
        InteractTarget();
    }
    

    /// <summary>
    /// Rozwi¹zuje uk³ad równañ na warunek prostad³oœci wektorów AB z XY i XY z CD (iloczyny skalarne wektorów, generalnie czarna magia XD)
    /// </summary>    
    /// 
    /// A(a,b,c) B(d,e,f) - krañce slidera
    /// C(k,l,m) D(n,o,p) - C-po³o¿enie kamery, D-punkt na przód od kamery (id¹cy od wektora forward {lub kursora dla kamery})
    /// 
    /// Szukamy alfa i bety takie ¿e:
    /// 
    /// X=(a+alfa(d-a), b+alfa(e-b),c+alfa(f-c))
    /// Y=(k+beta(n-k), l+beta(o-l),m+beta(p-m))
    /// 
    /// Tworzy nam siê uk³ad równañ
    /// I AB prostapad³e do XY
    /// II XY prostopad³e do CD
    /// 
    /// przekszta³camy do postaci:
    /// I  beta*A1 + alfa*B1= C1
    /// II beta*A2 + alfa*B2= C2
    /// 
    /// i rozwi¹zujemy metod¹ cramera
    /// 



    override protected void Move(Hand hand)
    {
        float a, b, c,   d, e, f;
        float k,l,m, n,o,p;             


        //AB - wektor slidera
        //a,b,c - wspólrzedne punktu A(a,b,c)
        a = minimumPos.transform.position.x;
        b = minimumPos.transform.position.y;
        c = minimumPos.transform.position.z;

        //d,e,f - wspólrzedne punktu B(d,e,f)
        d = maximumPos.transform.position.x;
        e = maximumPos.transform.position.y;
        f = maximumPos.transform.position.z;

        //wektor CD czyli ray od rêki
        //k,l,m - wspólrzedne punktu C(k,l,m)
        k = hand.transform.position.x;
        l = hand.transform.position.y;
        m = hand.transform.position.z;

        //n,o,p - wspólrzedne punktu D(n,o,p)
        n = hand.transform.position.x + hand.GetForwardVector().x;
        o = hand.transform.position.y + hand.GetForwardVector().y;
        p = hand.transform.position.z + hand.GetForwardVector().z;


        //tworzymy wspó³czynniki równania
        float A1, A2, B1, B2, C1, C2;

        A1 = (d - a) * (n - k) + (e - b) * (o - l) + (f - c) * (p - m);
        A2 = (n - k) * (n - k) + (o - l) * (o - l) + (p - m) * (p - m);

        B1 = -((d - a) * (d - a) + (e - b) * (e - b) + (f - c) * (f - c));
        B2 = -((n - k) * (d - a) + (o - l) * (e - b) + (p - m) * (f - c));

        C1 = -((d - a) * (k - a) + (e - b) * (l - b) + (f - c) * (m - c));
        C2 = -((n - k) * (k - a) + (o - l) * (l - b) + (p - m) * (m - c));

        //rozwi¹zujemy uk³ad równañ
        ///
        /// beta * A1 + alfa * B1 = C1
        /// beta * A2 + alfa * B2 = C2        
        /// 

        float W = A1 * B2 - A2 * B1;
        float Walfa = A1 * C2 - A2 * C1;
        float Wbeta = C1 * B2 - C2 * B1;

        float alfa, beta;

        alfa = Walfa / W;
        beta = Wbeta / W;

        Vector3 X = new Vector3(a + (d - a) * alfa, b + (e - b) * alfa, c + (f - c) * alfa);

        this.transform.position = X;        

    }


    private void ClampPos()
    {        
        Vector3 minPos = minimumPos.transform.localPosition;
        Vector3 maxPos = maximumPos.transform.localPosition;

        Vector3 AB = maxPos- minPos;
        Vector3 AC = transform.localPosition - minPos;

        float t = AC.x/AB.x;        
        transform.localPosition = Vector3.Lerp(minPos, maxPos, t);
        
    }

    private void CalcVal()
    {
        float distFromMin = minimumPos.transform.localPosition.x - transform.localPosition.x;
        float MaxDist = minimumPos.transform.localPosition.x - maximumPos.transform.localPosition.x;

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
