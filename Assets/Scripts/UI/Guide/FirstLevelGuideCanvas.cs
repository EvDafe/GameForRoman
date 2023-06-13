using Unity.VisualScripting;
using UnityEngine;

public class FirstLevelGuideCanvas : MonoBehaviour
{
    private Hand _hand;

    private void Start()
    {
        _hand = GetComponentInChildren<Hand>();
    }

    private void FixedUpdate()
    {
        if(Input.GetMouseButton((int)MouseButton.Left)) {
            Destroy(_hand.gameObject);
            Destroy(gameObject);
        }
    }
}
