using System;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] Camera _camera;
    [SerializeField] LayerMask _inputLayer;
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
        if (Physics.Raycast(_camera.ScreenPointToRay(Input.mousePosition), Mathf.Infinity, _inputLayer))
        {
            Physics.Raycast(_camera.ScreenPointToRay(Input.mousePosition), out RaycastHit hit);
            position = hit.point;
            Debug.Log(position);
        }
        else 
            position = Vector3.zero;
    }
}
