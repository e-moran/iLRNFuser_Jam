using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MissionController : MonoBehaviour
{
    private Events _events;
    private PlanetSpecification _currPlanetSpecification;
    private TextMeshPro _text;
    
    void Start()
    {
        _events = GameObject.Find("GameManager").GetComponent<Events>();
        _events.OnNewRound += OnNewRound;
        _text = gameObject.transform.Find("MissionText").GetComponent<TextMeshPro>();
    }

    void OnNewRound()
    {
        _currPlanetSpecification = new PlanetSpecification();
        _text.text = _currPlanetSpecification.ToString();
    }
}
