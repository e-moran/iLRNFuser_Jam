using System.Collections;
using UnityEngine;

public class PlanetSize : MonoBehaviour
{
    public float lerpTimer = 0.2f;

    private readonly float[] _scaleMapping = {
        0.4f, 0.5f, 0.6f // Our scales for the different options of planet sizes
    };

    public SelectorGroup selectorGroup;

    void Start()
    {
        selectorGroup.NewSelection += OnChanged;
    }

    void OnChanged()
    {
        StartCoroutine(LerpedScale());
    }

    IEnumerator LerpedScale()
    {
        float elapsedTime = 0;
        Vector3 startScale = transform.localScale;

        // Keep lerp'ing every frame until we reach the desired scale
        while (elapsedTime < lerpTimer)
        {
            yield return new WaitForEndOfFrame();
            elapsedTime += Time.deltaTime;
            transform.localScale = Vector3.Lerp(
                startScale, 
                new Vector3(1, 1, 0) * _scaleMapping[selectorGroup.Selected], 
                (elapsedTime / lerpTimer));
        }
    }
}
