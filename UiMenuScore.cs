using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UiMenuScore : MonoBehaviour
{
    private TextMeshPro _text;
    
    void Awake()
    {
        _text = GetComponent<TextMeshPro>();
    }

    public void UpdateScore(int newScore)
    {
        _text.text = newScore.ToString();
    }
}
