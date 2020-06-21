using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGameButton : MonoBehaviour
{
    private GameController _gameController;

    void Start()
    {
        _gameController = GameObject.Find("GameManager").GetComponent<GameController>();
    }

    void OnMouseDown()
    {
        _gameController.NewGame();
    }
}
