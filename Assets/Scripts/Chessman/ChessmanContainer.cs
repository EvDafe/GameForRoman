using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ChessmanContainer : MonoBehaviour
{
    [SerializeField] private List<EnemyChessman> _enemyChessmans;
    [SerializeField] private List<PlayerChessman> _playerChessmans;

    public List<EnemyChessman> EnemyChessmans => _enemyChessmans;
    public List<PlayerChessman> PlayerChessmans => _playerChessmans;
    public static ChessmanContainer Instance { get; private set; }
    public UnityEvent OnDeathChessman;

    private void Awake()
    {
        if (Instance == null)
            Instance = GetComponent<ChessmanContainer>();
        else
            throw new InvalidOperationException();
    }
    public void RemovePlayer(PlayerChessman playerChessman)
    {
        _playerChessmans.Remove(playerChessman);
    }
    public void AddPlayer(PlayerChessman playerChessman)
    {
        _playerChessmans.Add(playerChessman);
    }
    private void DeathPlayer(PlayerChessman playerChessman)
    {
        _playerChessmans.Remove(playerChessman);
        OnDeathChessman?.Invoke();
    }
    public void RemoveEnemy(EnemyChessman enemyChessman)
    {
        _enemyChessmans.Remove(enemyChessman);
    }
    public void AddEnemy(EnemyChessman enemyChessman)
    {
        _enemyChessmans.Add(enemyChessman);
    }
    private void DeathEnemy(EnemyChessman enemyChessman)
    {
        _enemyChessmans.Remove(enemyChessman);
        OnDeathChessman?.Invoke();
    }
    public void DeathChessman(Chessman chessman)
    {
        if (chessman is PlayerChessman playerChessman)
            DeathPlayer(playerChessman);
        else if (chessman is EnemyChessman enemyChessman)
            DeathEnemy(enemyChessman);
        else
            throw new InvalidOperationException();
    }
}
