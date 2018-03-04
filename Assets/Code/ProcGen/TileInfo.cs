using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileInfo
{
    public int xCoord;
    public int yCoord;
    public bool HasTile;

    public TileInfo(int x, int y)
    {
        xCoord = x;
        yCoord = y;
    }
}
