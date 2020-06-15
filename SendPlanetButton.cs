using System;
using System.Collections;
using UnityEngine;

public class SendPlanetButton : MonoBehaviour
{
    private GameController _gameController;
    private Sprite[] _stateSprites;
    private Action RedrawButton;
    private SpriteRenderer _spriteRenderer;

    private int state;
    private bool hovering;
    
    private const int DEFAULT = 0;
    private const int HOVER = 1;
    private const int CLICKED = 2;

    void Start()
    {
        RedrawButton += DrawButton;
        _gameController = GameObject.Find("GameManager").GetComponent<GameController>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        
        // Initialise all the states for the button to be in
        _stateSprites = new Sprite[3];
        _stateSprites[0] = Resources.Load<Sprite>("Images/SendPlanetButton/Default");
        _stateSprites[1] = Resources.Load<Sprite>("Images/SendPlanetButton/Hover");
        _stateSprites[2] = Resources.Load<Sprite>("Images/SendPlanetButton/Clicked");

        state = DEFAULT;
        RedrawButton.Invoke();
    }

    void DrawButton()
    {
        _spriteRenderer.sprite = _stateSprites[state];
    }

    void OnMouseDown()
    {
        _gameController.EndRound();
        StartCoroutine(DoAndResetButtonClick());
    }

    IEnumerator DoAndResetButtonClick()
    {
        state = CLICKED;
        RedrawButton?.Invoke();
        yield return new WaitForSeconds(0.2f);
        state = hovering ? HOVER : DEFAULT;
        RedrawButton?.Invoke();
    }

    private void OnMouseEnter()
    {
        if (state == DEFAULT)
        {
            state = HOVER;
            RedrawButton?.Invoke();
        }

        hovering = true;
    }

    private void OnMouseExit()
    {
        hovering = false;
        if (state == HOVER)
        {
            state = DEFAULT;
            RedrawButton?.Invoke();
        }

        hovering = false;
    }
}
