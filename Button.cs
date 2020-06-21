using System;
using System.Collections;
using UnityEngine;

public class Button : MonoBehaviour
{
    public Sprite defaultSprite;
    public Sprite hoverSprite;
    public Sprite clickedSprite;
    
    private Sprite[] _stateSprites;
    private Action RedrawButton;
    private SpriteRenderer _spriteRenderer;

    private int _state;
    private bool _hovering;
    
    private const int DEFAULT = 0;
    private const int HOVER = 1;
    private const int CLICKED = 2;

    void Awake()
    {
        RedrawButton += DrawButton;
        _spriteRenderer = GetComponent<SpriteRenderer>();
        
        _stateSprites = new[]
        {
            defaultSprite,
            hoverSprite,
            clickedSprite
        };
    }

    private void OnEnable()
    {
        _state = DEFAULT;
        RedrawButton.Invoke();
    }

    void DrawButton()
    {
        _spriteRenderer.sprite = _stateSprites[_state];
    }

    void OnMouseDown()
    {
        StartCoroutine(DoAndResetButtonClick());
    }

    IEnumerator DoAndResetButtonClick()
    {
        _state = CLICKED;
        RedrawButton?.Invoke();
        yield return new WaitForSeconds(0.2f);
        _state = _hovering ? HOVER : DEFAULT;
        RedrawButton?.Invoke();
    }

    private void OnMouseEnter()
    {
        if (_state == DEFAULT)
        {
            _state = HOVER;
            RedrawButton?.Invoke();
        }

        _hovering = true;
    }

    private void OnMouseExit()
    {
        _hovering = false;
        if (_state == HOVER)
        {
            _state = DEFAULT;
            RedrawButton?.Invoke();
        }

        _hovering = false;
    }
}