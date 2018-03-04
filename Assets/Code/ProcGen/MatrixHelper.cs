using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class MatrixHelper
{
    public static IEnumerable<TileInfo> GetBorderTiles(TileInfo[,] board)
    {
        var result = new List<TileInfo>();

        for (int x = 0; x < board.GetLength(0); x++)
        {
            for (int y = 0; y < board.GetLength(1); y++)
            {
                if (x == 0 || x == board.GetLength(0) - 1 || y == 0 || y == board.GetLength(1) - 1)
                {
                    result.Add(board[x, y]);
                }
            }
        }

        return result;
    }

    public static bool TileExists(int x, int y, TileInfo[,] board)
    {
        return x > 0 && x < board.GetLength(0) && y > 0 && y < board.GetLength(1);
    }

    public static bool IsTileBorderX(TileInfo tile, TileInfo[,] board)
    {
        return tile.xCoord == 0 || tile.xCoord == board.GetLength(0)-1;
    }

    public static bool IsTileBorderY(TileInfo tile, TileInfo[,] board)
    {
        return tile.yCoord == 0 || tile.yCoord == board.GetLength(1)-1;
    }
}
