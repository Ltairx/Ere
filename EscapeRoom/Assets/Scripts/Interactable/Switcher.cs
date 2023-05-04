using UnityEngine;

public class Switcher: Switcher<float> { }

public class Switcher<T> : Interactable<T>
{
    public AudioSource src1;
    public AudioClip sfx_1;
    [field: SerializeField] private GameObject mainObject;
    [field: SerializeField] private GameObject secondaryObject;
    
    protected override void OnStartInteract(Hand hand)
    {
        if (!mainObject.activeSelf)
            secondaryObject.SetActive(false);
        
        mainObject.SetActive(!mainObject.activeSelf);
        if (src1 != null && sfx_1 != null)
        {
            src1.clip = sfx_1;
            src1.Play();
        }
    }
}