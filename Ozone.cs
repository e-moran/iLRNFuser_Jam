using UnityEngine;

public class Ozone : MonoBehaviour
{
    public SelectorGroup selectorGroup;
    
    private Sprite[] _ozoneSprites;
    private SpriteRenderer _spriteRenderer;

    void Awake()
    {
        // We need to load all the ozone images from the resources folder and assign them to indices corresponding
        // To the 0-2 left-right numbering scheme used in the selector group
        _ozoneSprites = new [] {
            Resources.Load<Sprite>("Images/Planets/Ozone/Low"),
            Resources.Load<Sprite>("Images/Planets/Ozone/Medium"),
            Resources.Load<Sprite>("Images/Planets/Ozone/High")
        };
    }
    
    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        selectorGroup.NewSelection += OnChanged; // Add this to the event action
    }

    void OnChanged()
    {
        _spriteRenderer.sprite = _ozoneSprites[selectorGroup.Selected]; // Select the correct sprite
    }
}
