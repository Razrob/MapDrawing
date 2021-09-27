using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MapInstantiator : MonoBehaviour
{
    [SerializeField] private string _mapTilesPath;
    [SerializeField] private Vector3 _startInstantiatePosition;


    private Vector2Int CalculateOffcets(MapTileData _tileData)
    {
        Vector2Int _offcets = Vector2Int.zero;
        _offcets.x = Convert.ToInt32(_tileData.Id.Substring(_tileData.Id.IndexOfWithNumberOf('_', 3) + 1, _tileData.Id.IndexOfWithNumberOf('_', 4) - _tileData.Id.IndexOfWithNumberOf('_', 3) - 1));
        _offcets.y = Convert.ToInt32(_tileData.Id.Substring(_tileData.Id.IndexOfWithNumberOf('_', 2) + 1, _tileData.Id.IndexOfWithNumberOf('_', 3) - _tileData.Id.IndexOfWithNumberOf('_', 2) - 1));
        return _offcets;
    }

    private void CalculatePosition(MapTileData _tileData, Vector2Int _offcets, Vector2Int _lastOffcets, Vector2 _lastTileScale, ref Vector3 _position)
    {
        if (_offcets.x == 0) _position.x = 0;
        if (_offcets.y == 0) _position.y = 0;

        if (_lastOffcets.x < _offcets.x) _position.x += (_lastTileScale.x + _tileData.Width) / 2;
        if (_lastOffcets.y < _offcets.y) _position.y -= (_lastTileScale.y + _tileData.Height) / 2;
    }

    public void InstantiateTiles(MapTileList _mapTileList, out Vector2[] _bounds)
    {
        _bounds = new Vector2[2];

        Vector3 _currentPosition = Vector3.zero;

        Vector2Int _lastOffcets = Vector2Int.zero;
        Vector2 _lastTileScale = Vector2.zero;

        for(int i = 0; i < _mapTileList.List.Count; i++)
        {
            GameObject _tile = Resources.Load<GameObject>($"{_mapTilesPath}/{_mapTileList.List[i].Id}");

            Vector2Int _offcets = CalculateOffcets(_mapTileList.List[i]);
            CalculatePosition(_mapTileList.List[i], _offcets, _lastOffcets, _lastTileScale, ref _currentPosition);

            if (_tile != null) Instantiate(_tile, _startInstantiatePosition + _currentPosition, Quaternion.identity);

            _lastOffcets = _offcets;
            _lastTileScale = new Vector2(_mapTileList.List[i].Width, _mapTileList.List[i].Height);

            if (i == 0) _bounds[0] = new Vector2(_currentPosition.x - _mapTileList.List[i].Width / 2, _currentPosition.y + _mapTileList.List[i].Height / 2);
            if (i == _mapTileList.List.Count - 1) _bounds[1] = new Vector2(_currentPosition.x + _mapTileList.List[i].Width / 2, _currentPosition.y - _mapTileList.List[i].Height / 2);
        }
    }
}
