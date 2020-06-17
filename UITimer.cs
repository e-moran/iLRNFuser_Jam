using TMPro;
using UnityEngine;

public class UITimer : MonoBehaviour
{
    private TextMeshPro _text;
    void Start()
    {
        var gameController = GameObject.Find("GameManager").GetComponent<GameController>();
        gameController.TimeRemainingChanged += UpdateText;
        
        _text = GetComponent<TextMeshPro>();
        
        UpdateText(gameController.RemainingTime); // Set the initial time
    }

    void UpdateText(int newTime)
    {
        _text.text = newTime.ToString();
    }
}
