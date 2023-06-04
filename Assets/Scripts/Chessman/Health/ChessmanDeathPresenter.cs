using UnityEngine;

[RequireComponent(typeof(ChessmanHealth))]
public class ChessmanDeathPresenter : MonoBehaviour
{
    [SerializeField] private ParticleSystem _deathParticle;

    private ChessmanHealth _chessmanHealth;
    private void Start()
    {
        _chessmanHealth = GetComponent<ChessmanHealth>();
        _chessmanHealth.OnDeath.AddListener(CreateParticle);
    }

    private void CreateParticle()
    {
        Instantiate(_deathParticle, transform.position, Quaternion.identity);
    }
}
