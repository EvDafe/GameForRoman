using System;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private LayerMask _inputLayer;
    public static InputManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
            Instance = GetComponent<InputManager>();
        else
            throw new InvalidOperationException();
    }

    public T TryGetComponentAtMousePosition<T>(LayerMask layer) where T : Component
    {
        if(Physics.Raycast(_camera.ScreenPointToRay(Input.mousePosition), Mathf.Infinity, layer))
        {
            Physics.Raycast(_camera.ScreenPointToRay(Input.mousePosition), out RaycastHit hit, Mathf.Infinity, layer);
            if (hit.collider.TryGetComponent(out T findComponent))
                return findComponent;
        }
        return null;
    }
    public void GetMousePosition(out Vector3 position)
    {
        Physics.Raycast(_camera.ScreenPointToRay(Input.mousePosition), out RaycastHit hit, Mathf.Infinity, _inputLayer);
        position = hit.point;
    }
}
