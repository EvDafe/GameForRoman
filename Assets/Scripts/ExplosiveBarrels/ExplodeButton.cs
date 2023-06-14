using UnityEngine;

public class ExplodeButton : MonoBehaviour
{
    [SerializeField] ExplosiveBarrel _barrel;

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Chessman chessman))
            TryExplode();
    }

    private void TryExplode()
    {
        if(_barrel != null)
            _barrel.Explode();
    }
}
