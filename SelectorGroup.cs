using System;
using UnityEngine;

public class SelectorGroup : MonoBehaviour
{
    public Action NewSelection;
    public int Selected { get; private set; } = 1;

    public void InvokeNewSelection(int selector)
    {
        Selected = selector;
        NewSelection?.Invoke();
    }
}
