using System;
using UnityEngine;

public class SendPlanetButton : MonoBehaviour
{
    private Events _events;
    void Start()
    {
        _events = GameObject.Find("GameManager").GetComponent<Events>();
    }

    void OnMouseDown()
    {
        // TODO implement planet validation
        _events.InvokeNewRound();
    }
}
