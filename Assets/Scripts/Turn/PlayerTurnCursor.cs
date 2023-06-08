using System;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class PlayerTurnCursor : MonoBehaviour
{
    private LineRenderer _line;
    private Chessman _chessman;
    private ChessmanThrower _thrower;

    private void Start()
    {
        _line = GetComponent<LineRenderer>();
    }
    private void FixedUpdate()
    {
        ChangeEffect();
    }
    private void ChangeEffect()
    {
        InputManager.Instance.GetMousePosition(out Vector3 mousePosition);
        Vector3 to = transform.position.FindVectorBetween(mousePosition);
        float distance = Vector3.Distance(mousePosition, transform.position);
        if(distance > _thrower.MaxThrowDistance)
            distance = _thrower.MaxThrowDistance;
        _line.SetPosition(1, to.normalized * distance);
    }
    public void SetChessman(Chessman chessman)
    {
        if (chessman == null)
            throw new ArgumentException();

        _chessman = chessman;
        _thrower = _chessman.GetComponent<ChessmanThrower>();
    }
}
