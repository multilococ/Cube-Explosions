using UnityEngine;

public class Clicker : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private Spawner _spawner;
    [SerializeField] private Bomber _bomber;

    private Cube _cube;

    private void Update()
    {
        RaycastHit hit;
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit) && Input.GetMouseButtonDown(0))
        {
            if (hit.transform.TryGetComponent<Cube>(out _cube))
            {
                _spawner.SetCube(_cube);
                _bomber.SetCube(_cube);
                _cube.DestroyObjectWithChance(); 
            }
        }
    }
}
