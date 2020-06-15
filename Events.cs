using System;
using UnityEngine;

public class Events: MonoBehaviour
{
    public event Action<PlanetSpecification> OnNewRound; // An event to be used to restart the round

    public void InvokeNewRound(PlanetSpecification planetSpecification)
    {
        OnNewRound?.Invoke(planetSpecification);
    }
}
