using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class Chessman—ontainer : MonoBehaviour
{
    [SerializeField] private List<EnemyChessman> _enemyChessmans;
    [SerializeField] private List<PlayerChessman> _playerChessmans;

    public List<EnemyChessman> EnemyChessmans => _enemyChessmans = FindObjectsByType<EnemyChessman>(0).ToList();
    public List<PlayerChessman> PlayerChessmans => _playerChessmans = FindObjectsByType<PlayerChessman>(0).ToList();
    public static Chessman—ontainer Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
            Instance = GetComponent<Chessman—ontainer>();
        else
            throw new InvalidOperationException();

        _enemyChessmans = FindObjectsByType<EnemyChessman>(0).ToList();
        _playerChessmans = FindObjectsByType<PlayerChessman>(0).ToList();
    }
    private void SubscriptionOnDeath(IEnumerable<Chessman> chessmans, UnityAction<Chessman> action)
    {
        List<ChessmanHealth> chessmanHealths = new();
        foreach(var chess in chessmans)
        {
            chessmanHealths.Add(chess.GetComponent<ChessmanHealth>());
        }
        chessmanHealths.ForEach( x => x.Died.AddListener(action));
    }
    private void RemovePlayer(Chessman playerChessman)
    {
        _playerChessmans.Remove((PlayerChessman)playerChessman);
    }
    private void RemoveEnemy(Chessman enemyChessman)
    {
        _enemyChessmans.Remove((EnemyChessman)enemyChessman);
    }
}
