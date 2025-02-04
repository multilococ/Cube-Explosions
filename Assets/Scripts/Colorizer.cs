using UnityEngine;

public class Colorizer 
{
    public void SetRandomColor(Renderer renderer)
    {
        Color randomColor =  new Color(Random.value, Random.value, Random.value);
        
        renderer.material.color = randomColor;
    }
}
