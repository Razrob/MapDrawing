using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Initializer : MonoBehaviour
{
    [SerializeField] private TileListDeserializator _tileListDeserializator;
    [SerializeField] private MapInstantiator _mapInstantiator;

    [SerializeField] private CameraMover _cameraMover;
    [SerializeField] private CameraBoundsLimiter _cameraBoundsLimiter;

    [SerializeField] private GameProcessHandler _gameProcessHandler;

    private void Awake()
    {
        Vector2[] _cameraBounds;
        _mapInstantiator.InstantiateTiles(_tileListDeserializator.GetMapTileList(), out _cameraBounds);
        _cameraBoundsLimiter.Bounds = _cameraBounds;
        _cameraBoundsLimiter.CalculateCameraBounds();

        _gameProcessHandler.onGamePauseWasChanged += (_enabled) => _cameraMover.enabled = !_enabled;
    }

    private void OnDestroy()
    {
        _gameProcessHandler.onGamePauseWasChanged -= (_enabled) => _cameraMover.enabled = !_enabled;
    }

}
