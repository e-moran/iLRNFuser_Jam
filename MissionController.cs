using TMPro;
using UnityEngine;

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

    void OnNewRound(PlanetSpecification planetSpecification)
    {
        _currPlanetSpecification = planetSpecification;
        _text.text = _currPlanetSpecification.ToString();
    }
}
