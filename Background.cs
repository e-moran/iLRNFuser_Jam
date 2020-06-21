using UnityEngine;

public class Background : MonoBehaviour
{
    public Sprite[] backgrounds;
    public SelectorGroup selector;

    private SpriteRenderer _spriteRenderer;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        selector.NewSelection += OnChanged;
    }

    private void OnChanged()
    {
        _spriteRenderer.sprite = backgrounds[selector.Selected];
    }
}