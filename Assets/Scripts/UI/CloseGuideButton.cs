using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class CloseGuideButton : MonoBehaviour
{
    [SerializeField] private Canvas _guideCanvas;

    public void CloseGuide()
    {
        Destroy(_guideCanvas);
    }
}
