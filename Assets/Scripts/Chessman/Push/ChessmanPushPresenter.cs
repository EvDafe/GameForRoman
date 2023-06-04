using UnityEngine;

[RequireComponent(typeof(ChessmanPusher))]
public class ChessmanPushPresenter : MonoBehaviour
{
    [SerializeField] private ParticleSystem _pushEffect;
    private ChessmanPusher _chessmanPusher;
    private void Start()
    {
        _chessmanPusher = GetComponent<ChessmanPusher>();
        _chessmanPusher.OnPush.AddListener(CreateParticle);
    }
    private void CreateParticle()
    {
        Instantiate(_pushEffect, transform.position, Quaternion.identity);
    }

}
