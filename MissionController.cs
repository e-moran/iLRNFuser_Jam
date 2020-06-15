using TMPro;
using UnityEngine;

public class MissionController : MonoBehaviour
{
    private GameController _gameController;
    private PlanetSpecification _currPlanetSpecification;
    private TextMeshPro _text;
    
    void Start()
    {
        _gameController = GameObject.Find("GameManager").GetComponent<GameController>();
        _gameController.OnNewRound += OnNewRound;
        _text = gameObject.transform.Find("MissionText").GetComponent<TextMeshPro>();
    }

    void OnNewRound(PlanetSpecification planetSpecification)
    {
        _currPlanetSpecification = planetSpecification;
        _text.text = _currPlanetSpecification.ToString();
    }
}
