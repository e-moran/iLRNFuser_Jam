using UnityEngine;

public class Selector : MonoBehaviour
{
    public int selectorId = 0;
    
    private SelectorGroup _group;
    private SpriteRenderer _renderer;
    
    void Start()
    {
        _group = transform.parent.GetComponent<SelectorGroup>(); // Get the parent which must contain a selector group
        _group.OnNewSelection += OnNewSelection;
        _renderer = GetComponent<SpriteRenderer>();
        _renderer.enabled = false;
    }

    void OnNewSelection(int id)
    {
        _renderer.enabled = id == selectorId; // Selector shadow will be visible if this is the correct selector
    }

    void OnMouseDown()
    {
        _group.InvokeNewSelection(selectorId);
    }
}
