using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    public TreeNode X, Y, Z, N, S, W, E;

    protected void ResetTree()
    {
        X.MatteMaterial();
        Y.MatteMaterial();
        Z.MatteMaterial();
        N.MatteMaterial();
        S.MatteMaterial();
        W.MatteMaterial();
        E.MatteMaterial();
    }


    public void SetX(int x)
    {
        X.SetText("T<=" + x);
    }

    public void SetY(int y)
    {
        Y.SetText("T<=" + y);
    }
    public void SetZ(int z)
    {
        Z.SetText("T<=" + z);
    }

    public void LightTree(DIRECTION direction)
    {
        ResetTree();
        switch (direction)
        {
            case DIRECTION.NORTH:                
                X.LightMaterial();
                Y.LightMaterial();
                N.LightMaterial();
                break;
            case DIRECTION.WEST:
                X.LightMaterial();
                S.LightMaterial();
                break;
            case DIRECTION.EAST:
                Z.LightMaterial();
                W.LightMaterial();
                break;
            case DIRECTION.SOUTH:
                E.LightMaterial();                
                break;
        }
    }
}
