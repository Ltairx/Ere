using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEditor;
using UnityEngine.UI;

public class TransmitationController : Riddle
{
    public TMP_Text s_3;
    public TMP_Text s_2;
    public TMP_Text s_1;
    public TMP_Text s_0;
    public TMP_Text bt1;
    public TMP_Text bt2;
    public TMP_Text bt3;
    public TMP_Text bt4;
    private int a = 3, b = 3, c = 3, d = 3; //rozwiazanie - 5 1 2 4/5 2 1 4
    private bool done = false;
    private float total_perc = 0f;

    public RawImage Transmitancja;
    public Texture Trans_solved;

    protected override void Start()
    {
        base.Start();
        bt1.text = a.ToString();
        bt2.text = b.ToString();
        bt3.text = c.ToString();
        bt4.text = d.ToString();

        s_3.text = d.ToString();
        s_2.text = (c * d + b * d).ToString();
        s_1.text = (a + b * c * d).ToString();
        s_0.text = a.ToString();
    }

    // Update is called once per frame
    void Update()
    {
    }
    public override Delegate GetFunction(int index)
    {
        switch (index)
        {
            case 0:
                return (Action<float>)Decrement1;
            case 1:
                return (Action<float>)Increment1;
            case 2:
                return (Action<float>)Decrement2;
            case 3:
                return (Action<float>)Increment2;
            case 4:
                return (Action<float>)Decrement3;
            case 5:
                return (Action<float>)Increment3;
            case 6:
                return (Action<float>)Decrement4;
            case 7:
                return (Action<float>)Increment4;
            default:
                return null;
        }
    }

    private void Increment1(float not_used)
    {
        if (!done)
        {
            a++;
            if (a > 9)
            {
                a = 1;
            }
            else if (a < 1)
            {
                a = 9;
            }
            bt1.text = a.ToString();
            bt2.text = b.ToString();
            bt3.text = c.ToString();
            bt4.text = d.ToString();

            s_3.text = d.ToString();
            s_2.text = (c * d + b * d).ToString();
            s_1.text = (a + b * c * d).ToString();
            s_0.text = a.ToString();
            if ((a == 5 && b == 1 && c == 2 && d == 4 && !done) || (a == 5 && b == 2 && c == 1 && d == 4 && !done))
            {
                done = true;
                OnSolve();
            }
        }
    }
    private void Decrement1(float not_used)
    {
        if (!done)
        {
            a--;
            if (a > 9)
            {
                a = 1;
            }
            else if (a < 1)
            {
                a = 9;
            }
            bt1.text = a.ToString();
            bt2.text = b.ToString();
            bt3.text = c.ToString();
            bt4.text = d.ToString();

            s_3.text = d.ToString();
            s_2.text = (c * d + b * d).ToString();
            s_1.text = (a + b * c * d).ToString();
            s_0.text = a.ToString();
            if ((a == 5 && b == 1 && c == 2 && d == 4 && !done) || (a == 5 && b == 2 && c == 1 && d == 4 && !done))
            {
                done = true;
                OnSolve();
            }
        }
    }
    private void Increment2(float not_used)
    {
        if (!done)
        {
            b++;
            if (b > 9)
            {
                b = 1;
            }
            else if (b < 1)
            {
                b = 9;
            }
            bt1.text = a.ToString();
            bt2.text = b.ToString();
            bt3.text = c.ToString();
            bt4.text = d.ToString();

            s_3.text = d.ToString();
            s_2.text = (c * d + b * d).ToString();
            s_1.text = (a + b * c * d).ToString();
            s_0.text = a.ToString();
            if ((a == 5 && b == 1 && c == 2 && d == 4 && !done) || (a == 5 && b == 2 && c == 1 && d == 4 && !done))
            {
                done = true;
                OnSolve();
            }
        }
    }
    private void Decrement2(float not_used)
    {
        if (!done)
        {
            b--;
            if (b > 9)
            {
                b = 1;
            }
            else if (b < 1)
            {
                b = 9;
            }
            bt1.text = a.ToString();
            bt2.text = b.ToString();
            bt3.text = c.ToString();
            bt4.text = d.ToString();

            s_3.text = d.ToString();
            s_2.text = (c * d + b * d).ToString();
            s_1.text = (a + b * c * d).ToString();
            if ((a == 5 && b == 1 && c == 2 && d == 4 && !done) || (a == 5 && b == 2 && c == 1 && d == 4 && !done))
            {
                done = true;
                OnSolve();
            }
        }
    }
    private void Increment3(float not_used)
    {
        if (!done)
        {
            c++;
            if (c > 9)
            {
                c = 1;
            }
            else if (c < 1)
            {
                c = 9;
            }
            bt1.text = a.ToString();
            bt2.text = b.ToString();
            bt3.text = c.ToString();
            bt4.text = d.ToString();

            s_3.text = d.ToString();
            s_2.text = (c * d + b * d).ToString();
            s_1.text = (a + b * c * d).ToString();
            s_0.text = a.ToString();
            if ((a == 5 && b == 1 && c == 2 && d == 4 && !done) || (a == 5 && b == 2 && c == 1 && d == 4 && !done))
            {
                done = true;
                OnSolve();
            }
        }
    }
    private void Decrement3(float not_used)
    {
        if (!done)
        {
            c--;
            if (c > 9)
            {
                c = 1;
            }
            else if (c < 1)
            {
                c = 9;
            }
            bt1.text = a.ToString();
            bt2.text = b.ToString();
            bt3.text = c.ToString();
            bt4.text = d.ToString();

            s_3.text = d.ToString();
            s_2.text = (c * d + b * d).ToString();
            s_1.text = (a + b * c * d).ToString();
            s_0.text = a.ToString();
            if ((a == 5 && b == 1 && c == 2 && d == 4 && !done) || (a == 5 && b == 2 && c == 1 && d == 4 && !done))
            {
                done = true;
                OnSolve();
            }
        }
    }
    private void Increment4(float not_used)
    {
        if (!done)
        {
            d++;
            if (d > 9)
            {
                d = 1;
            }
            else if (d < 1)
            {
                d = 9;
            }
            bt1.text = a.ToString();
            bt2.text = b.ToString();
            bt3.text = c.ToString();
            bt4.text = d.ToString();

            s_3.text = d.ToString();
            s_2.text = (c * d + b * d).ToString();
            s_1.text = (a + b * c * d).ToString();
            s_0.text = a.ToString();
            if ((a == 5 && b == 1 && c == 2 && d == 4 && !done) || (a == 5 && b == 2 && c == 1 && d == 4 && !done))
            {
                done = true;
                OnSolve();
            }
        }
    }
    private void Decrement4(float not_used)
    {
        if (!done)
        {
            d--;
            if (d > 9)
            {
                d = 1;
            }
            else if (d < 1)
            {
                d = 9;
            }
            bt1.text = a.ToString();
            bt2.text = b.ToString();
            bt3.text = c.ToString();
            bt4.text = d.ToString();

            s_3.text = d.ToString();
            s_2.text = (c * d + b * d).ToString();
            s_1.text = (a + b * c * d).ToString();
            s_0.text = a.ToString();
            if ((a == 5 && b == 1 && c == 2 && d == 4 && !done) || (a == 5 && b == 2 && c == 1 && d == 4 && !done))
            {
                done = true;
                OnSolve();
            }
        }
    }

    protected override void OnSolve()
    {
        Transmitancja.texture = Trans_solved;
        total_perc = 1f;
        base.OnSolve();
    }

    public override float GetSolvePercentage()
    {
        if(!done)
        {
            if (a == 5) total_perc += 0.25f;
            if ((b == 1 && c == 2) || (b == 2 && c == 1)) total_perc += 0.5f;
            else if (b == 1 || b == 2) total_perc += 0.25f;
            else if (c == 1 || c == 2) total_perc += 0.25f;
            if (d == 4) total_perc += 0.25f;
        }
        return total_perc;
    }
}
