using UnityEngine;

public class PlanetSize : MonoBehaviour
{
    private readonly float[] _scaleMapping = {
        0.35f, 0.5f, 0.65f
    };

    public SelectorGroup selectorGroup;

    void Start()
    {
        selectorGroup.NewSelection += OnChanged;
    }

    void OnChanged()
    {
        transform.localScale = (new Vector3(1, 1, 0)) * _scaleMapping[selectorGroup.Selected];
    }
}
