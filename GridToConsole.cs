using UnityEngine;

public class GridToConsole : MonoBehaviour
{
    void Update()
    {
        var _grid = GameObject.Find("CloudManager").GetComponent<Grid>();
        Debug.Log(_grid.LocalToCell(transform.localPosition));
    }
}
