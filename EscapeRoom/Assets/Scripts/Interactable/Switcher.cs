using UnityEngine;

public class Switcher: Switcher<float> { }

public class Switcher<T> : Interactable<T>
{
    [field: SerializeField] private GameObject mainObject;
    [field: SerializeField] private GameObject secondaryObject;
    
    protected override void OnStartInteract(Hand hand)
    {
        if (!mainObject.activeSelf)
            secondaryObject.SetActive(false);
        
        mainObject.SetActive(!mainObject.activeSelf);
    }
}