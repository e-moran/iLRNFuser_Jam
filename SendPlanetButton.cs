﻿using UnityEngine;

public class SendPlanetButton : MonoBehaviour
{
    private GameController _gameController;

    void Start()
    {
        _gameController = GameObject.Find("GameManager").GetComponent<GameController>();
    }

    void OnMouseDown()
    {
        _gameController.EndRound();
    }
}
