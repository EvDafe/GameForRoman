using UnityEngine;

[RequireComponent(typeof(ExplosiveBarrel))]
public class ExplodePresenter : MonoBehaviour
{
    [SerializeField] private ParticleSystem _explodeParticle;

    private ExplosiveBarrel _barrel;

    private void Start()
    {
        _barrel = GetComponent<ExplosiveBarrel>();
        _barrel.OnExplode.AddListener(CreateEffect);
    }

    private void CreateEffect()
    {
        Instantiate(_explodeParticle,transform.position,Quaternion.identity);
    }
}
