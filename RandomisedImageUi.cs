using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RandomisedImageUi : MonoBehaviour
{
    private TextMeshPro _text;
    
    void Start()
    {
        _text = GetComponent<TextMeshPro>();
    }

    public void NewName(string name)
    {
        _text.text = name;
    }
}
