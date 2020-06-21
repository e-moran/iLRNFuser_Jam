using UnityEngine;

public class CloudManager : MonoBehaviour
{
    public SelectorGroup selectorGroup;
    public SpriteRenderer[] clouds;

    private float[] _opacityMapping =
    {
        0.0f,
        0.4f,
        0.8f
    };

    void Start()
    {
        selectorGroup.NewSelection += OnChanged;
    }

    void OnChanged()
    {
        foreach (var c in clouds)
        {
            c.color = new Color(1, 1, 1, _opacityMapping[selectorGroup.Selected]);
        }
    }
}
