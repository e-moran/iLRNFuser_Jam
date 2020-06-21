using System.IO;
using UnityEngine;
using Random = UnityEngine.Random;

public class RandomisedImage : MonoBehaviour
{
    public string resourceFolder;
    public RandomisedImageUi uiNameComponent;
    
    private Sprite[] _sprites;
    private string[] _names;
    private GameController _gameController;
    private SpriteRenderer _spriteRenderer;
    
    void Start()
    {
        DirectoryInfo levelDirectoryPath = new DirectoryInfo(Application.dataPath + "/Resources/" + resourceFolder);
        FileInfo[] planets = levelDirectoryPath.GetFiles("*.png", SearchOption.TopDirectoryOnly);
        
        _sprites = new Sprite[planets.Length];
        _names = new string[planets.Length];
        
        for (int i = 0; i < planets.Length; i++)
        {
            var currPlanetName = planets[i].Name.Substring(0,  planets[i].Name.Length - 4);
            _sprites[i] = Resources.Load<Sprite>(resourceFolder + currPlanetName);
            _names[i] = currPlanetName;
        }
        
        _gameController = GameObject.Find("GameManager").GetComponent<GameController>();
        _gameController.OnNewRound += OnNewRound;
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnNewRound(PlanetSpecification planetSpecification)
    {
        int i = Random.Range(0, _sprites.Length);
        _spriteRenderer.sprite = _sprites[i];
        
        if (uiNameComponent != null)
        {
            uiNameComponent.NewName(_names[i]);
        }
    }

    
}
