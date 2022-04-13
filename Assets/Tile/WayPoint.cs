using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviour
{
    [SerializeField] private Tower _towerPrefab;
    [SerializeField] private bool _isPlaceable;

    public bool IsPlaceable { get { return _isPlaceable; } }

    private void OnMouseDown()
    {
        if (_isPlaceable)
        {
            bool isPlaced = _towerPrefab.CreateTower(_towerPrefab, transform.position);

            _isPlaceable = !isPlaced;
        }
    }
}
