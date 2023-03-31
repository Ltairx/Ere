using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// literaly interface foc interactables. Needed to rpeserve genericity in interactables
/// 
/// 
/// All interactables need now 2 materials. The basic one, 
/// and the outline material
/// </summary>
public class InteractableInterface : MonoBehaviour
{
    private int outlineTicks=0;
    private bool outlineShown=false;

    Material outlineMaterial;

    bool hasRenderer = false;

    MaterialPropertyBlock outlineProperties;
    Renderer renderer;
    protected virtual void Start()
    {
        outlineProperties = new MaterialPropertyBlock();
        renderer = GetComponent<Renderer>();
        if(gameObject.GetComponent<Renderer>() != null)
        {            


            //adding outline material
            hasRenderer = true;
            Material[] mats = new Material[renderer.materials.Length + 1];

            for(int i = 0; i < renderer.materials.Length; i++)
            {
                mats[i] = renderer.materials[i];
            }

            const string matPath = "Materials/InteractableOutline";
            outlineMaterial = Resources.Load(matPath, typeof(Material)) as Material; ;
            if (outlineMaterial == null)
            {
                Debug.LogError("Outline material not in path: " + matPath + " for object: " + gameObject.name);

            }
            else
            {                
                mats[renderer.materials.Length] = outlineMaterial;
                renderer.sharedMaterials = mats;                
                renderer.GetPropertyBlock(outlineProperties,renderer.materials.Length-1);
            }

        }
        else
        {
            hasRenderer = false;
        }
    }


    protected virtual void Update()
    {
        if (outlineTicks > 0) outlineTicks--;
        if (outlineTicks == 0 && outlineShown) HideOutline();
    }
    virtual public void Interact(Hand hand){}
    virtual public void ShowOutline(){
        outlineShown = true;
        outlineProperties.SetInt("_Active", 1);
        outlineTicks = 2;
        if (renderer != null)
        {
            renderer.SetPropertyBlock(outlineProperties);
        }
    }

    virtual protected void HideOutline()
    {
        outlineShown = false;
        outlineProperties.SetInt("_Active", 0);
        if (renderer != null)
        {
            renderer.SetPropertyBlock(outlineProperties);
        }
    }
}
