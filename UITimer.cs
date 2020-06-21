using TMPro;
using UnityEngine;

public class UITimer : MonoBehaviour
{
    private TextMeshPro _text;
    private GameController _gameController;
    void Start()
    {
        _gameController = GameObject.Find("GameManager").GetComponent<GameController>();
        _gameController.TimeRemainingChanged += UpdateText;
        _gameController.OnNewGame += UpdateText;
        
        _text = GetComponent<TextMeshPro>();
    }

    void UpdateText()
    {
        _text.text = _gameController.RemainingTime.ToString();
    }

    void UpdateText(int newTime)
    {
        _text.text = newTime.ToString();
    }
}
