using System;
using UnityEngine;
using UnityEngine.UI;

public class Events: MonoBehaviour
{

    public event Action OnNewRound;

    private void Start()
    {
        GameObject.Find("NewRoundButton").GetComponent<Button>().onClick.AddListener(InvokeNewRound);
    }

    public void InvokeNewRound()
    {
        OnNewRound?.Invoke();
    }
}
