using System;
using UnityEngine;

public class SelectorGroup : MonoBehaviour
{
    public Action<int> OnNewSelection;
    public int Selected { get; private set; }

    public void InvokeNewSelection(int selector)
    {
        Selected = selector;
        OnNewSelection?.Invoke(selector);
    }
}
