using System;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Chessman), typeof(ChessmanHealth))]
public class ChessmanLevelUpper : MonoBehaviour
{
    [SerializeField] private Chessman _nextLevelPrefab;

    private ChessmanHealth _chessmanHealth;
    private ChessmanLevelUpper _myKiller;

    public UnityEvent OnLevelUp;
    private void Start()
    {
        _chessmanHealth = GetComponent<ChessmanHealth>();
        _chessmanHealth.OnDeath.AddListener(TryLevelUpKiller);
    }
    private void TryLevelUpKiller()
    {
        if(_myKiller != null )
            _myKiller.LevelUp();
    }
    public void LevelUp()
    {
        Instantiate(_nextLevelPrefab, transform.position, transform.rotation);
        Destroy(gameObject);
    }
    public void RemoveKiller()
    {
        _myKiller = null;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.TryGetComponent(out ChessmanLevelUpper levelUpper))
        {
            _myKiller = levelUpper;
        }
    }
}
