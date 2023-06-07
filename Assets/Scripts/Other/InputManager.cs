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

    public void TryGetComponentAtMousePosition<T>(out T component) where T : Component
    {
        Physics.Raycast(_camera.ScreenPointToRay(Input.mousePosition), out RaycastHit hit);
        if(hit.collider.TryGetComponent<T>(out T findComponent))
            component = findComponent;
        else
            component = null;
    }
    public void GetMousePosition(out Vector3 position)
    {
        Physics.Raycast(_camera.ScreenPointToRay(Input.mousePosition), out RaycastHit hit, Mathf.Infinity, _inputLayer);
        position = hit.point;
        Debug.Log(position);
    }
}
