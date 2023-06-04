using UnityEngine;

[RequireComponent(typeof(ChessmanLevelUpper))]
public class LevelUpPresenter : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particlePrefab;
    private ChessmanLevelUpper _levelUpper;

    private void Start()
    {
        _levelUpper = GetComponent<ChessmanLevelUpper>();
        _levelUpper.OnLevelUp.AddListener(CreateParticle);
    }

    private void CreateParticle()
    {
        Instantiate(_particlePrefab, transform.position, Quaternion.identity);
    }
}
