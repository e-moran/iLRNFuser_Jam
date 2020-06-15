using UnityEngine;
using Random = UnityEngine.Random;

public class Planet : MonoBehaviour
{
    private Sprite[] _planetSprites;
    private GameController _gameController;
    private SpriteRenderer _spriteRenderer;
    
    void Start()
    {
        _planetSprites = Resources.LoadAll<Sprite>("Images/Planets");
        _gameController = GameObject.Find("GameManager").GetComponent<GameController>();
        _gameController.OnNewRound += OnNewRound;
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _gameController.InvokeNewRound(new PlanetSpecification());
    }

    void OnNewRound(PlanetSpecification planetSpecification)
    {
        _spriteRenderer.sprite = _planetSprites[Random.Range(0, _planetSprites.Length)];
        transform.eulerAngles = new Vector3(0, 0, Random.Range(-30.0f, 30.0f));
    }

    
}
