using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CellsExtensions
{
    public static Vector3Int GetCellDirection(this TileMapSampler.Direction d)
    {
        return TileMapSampler.directionsCell[(int)d];
    }
}
