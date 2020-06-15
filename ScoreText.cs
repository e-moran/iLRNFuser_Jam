using TMPro;
using UnityEngine;

public class ScoreText : MonoBehaviour
{
    public GameController gameController;
    private TextMeshPro _text;
    
    void Start()
    {
        gameController.ScoreChanged += RefreshScore;
        _text = GetComponent<TextMeshPro>();
    }

    void RefreshScore(int newScore)
    {
        _text.text = newScore.ToString();
    }
}
