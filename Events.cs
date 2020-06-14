using System;
using UnityEngine;

public class Events: MonoBehaviour
{

    public event Action OnNewRound;

    public void InvokeNewRound()
    {
        OnNewRound?.Invoke();
    }
}
