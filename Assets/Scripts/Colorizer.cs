using UnityEngine;

public class Colorizer : MonoBehaviour
{
    [SerializeField] private Renderer _renderer;

    private Color _randomColor;

    private void Start()
    {
        _randomColor = GetRandomColor();
        _renderer.material.color = _randomColor;
    }

    private Color GetRandomColor()
    {
        return new Color(Random.value, Random.value, Random.value);
    }
}
