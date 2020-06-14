using UnityEngine;
using Random = UnityEngine.Random;

public class Planet : MonoBehaviour
{
    private Sprite[] _planetSprites;
    private Events _events;
    private SpriteRenderer _spriteRenderer;
    
    void Start()
    {
        _planetSprites = Resources.LoadAll<Sprite>("Images/Planets");
        _events = GameObject.Find("GameManager").GetComponent<Events>();
        _events.OnNewRound += OnNewRound;
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _events.InvokeNewRound();
    }

    void OnNewRound()
    {
        _spriteRenderer.sprite = _planetSprites[Random.Range(0, _planetSprites.Length)];
        transform.eulerAngles = new Vector3(0, 0, Random.Range(-30.0f, 30.0f));
    }

    
}
