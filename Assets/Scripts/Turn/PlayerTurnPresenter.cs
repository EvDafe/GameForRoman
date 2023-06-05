using System;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerTurnPresenter : MonoBehaviour
{
    [SerializeField] private LineRenderer _linePrefab;
    [SerializeField] private float _floorMargin;
    private LineRenderer _line;
    

    public void Present(Chessman chessman, Camera camera)
    {
        TryChangeEffect(chessman, camera);
    }
    public void TrySpawnEffect(Chessman chessman)
    {
        if(chessman != null) 
            _line = Instantiate(_linePrefab, chessman.transform.position + Vector3.up, Quaternion.identity);
    }
    private void TryChangeEffect(Chessman chessman, Camera camera)
    {
        if(_line != null)
        {
            Physics.Raycast(camera.ScreenPointToRay(Input.mousePosition), out RaycastHit hit);
            Vector3 mousePosition = hit.point;
            Vector3 to = chessman.transform.position.FindVectorBetween(mousePosition);
            var thrower = chessman.GetComponent<ChessmanThrower>();
            float distance = Vector3.Distance(mousePosition, chessman.transform.position);

            if (distance > thrower.MaxThrowDistance)
                distance = thrower.MaxThrowDistance;
            _line.SetPosition(1, to.normalized * distance);
        }
    }
    public void TryDeleteEffect()
    {
        if(_line != null) 
            Destroy(_line.gameObject);
    }
}
