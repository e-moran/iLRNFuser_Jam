using System;
using UnityEngine;

public class SelectorGroup : MonoBehaviour
{
    public Action NewSelection;
    public int startingValue = 1;
    public int Selected { get; private set; } = 1;

    void Awake()
    {
        Selected = startingValue;
    }
    
    public void InvokeNewSelection(int selector)
    {
        Selected = selector;
        NewSelection?.Invoke();
    }
}
