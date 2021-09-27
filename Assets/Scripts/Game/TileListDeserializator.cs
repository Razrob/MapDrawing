using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileListDeserializator : MonoBehaviour
{
    [SerializeField] private string _jsonPath;
    
    public MapTileList GetMapTileList()
    {
        string _json = Resources.Load(_jsonPath).ToString();
        MapTileList _mapTileList = JsonUtility.FromJson<MapTileList>(_json);

        return _mapTileList;
    }
}
