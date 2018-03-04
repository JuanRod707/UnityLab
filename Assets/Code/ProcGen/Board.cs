using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class Board : MonoBehaviour
{
    public BoardInfo BoardInfo;
    public GameObject TilePf;
    public GameObject RoomPf;
    public int seed;
    public bool debugMode;

    private TileInfo[,] tileMatrix;

    void Start()
    {
        GenerateBoard();
        DrawBoard();
    }

    void GenerateBoard()
    {
        if (seed != 0)
        {
            Random.InitState(seed);
        }

        tileMatrix = new TileInfo[Random.Range(BoardInfo.MinWidth, BoardInfo.MaxWidth),
            Random.Range(BoardInfo.MinHeight, BoardInfo.MaxHeight)];

        Debug.Log(string.Format("Building matrix of {0} by {1}", tileMatrix.GetLength(0), tileMatrix.GetLength(1)));

        for (int x = 0; x < tileMatrix.GetLength(0); x++)
        {
            for (int y = 0; y < tileMatrix.GetLength(1); y++)
            {
                tileMatrix[x, y] = new TileInfo(x, y);
            }
        }

        var borderTiles = MatrixHelper.GetBorderTiles(tileMatrix).ToList();
        borderTiles = borderTiles
            .Where(t => (t.yCoord > BoardInfo.MinRoomSize &&
                         t.yCoord < tileMatrix.GetLength(1) - BoardInfo.MinRoomSize) &&
                        (t.xCoord == 0 || t.xCoord == tileMatrix.GetLength(0) - 1))
            .Union(borderTiles.Where(
                t => (t.xCoord > BoardInfo.MinRoomSize &&
                      t.xCoord < tileMatrix.GetLength(0) - BoardInfo.MinRoomSize) &&
                     (t.yCoord == 0 || t.yCoord == tileMatrix.GetLength(1) - 1))).ToList();

        if (!debugMode)
        {
            var initialCorridors = Mathf.Min(tileMatrix.GetLength(0), tileMatrix.GetLength(1)) /
                                   (BoardInfo.MinRoomSize + 1);

            Debug.Log(string.Format("Building {0} corridors", initialCorridors));
            while (initialCorridors > 0 && borderTiles.Any())
            {
                var corridorStart = borderTiles.PickOne();
                if (MatrixHelper.IsTileBorderX(corridorStart, tileMatrix))
                {
                    Debug.Log(string.Format("Building corridor on y = {0}", corridorStart.yCoord));
                    for (int x = 0; x < tileMatrix.GetLength(0); x++)
                    {
                        tileMatrix[x, corridorStart.yCoord].HasTile = true;
                    }

                    var tilesToKill =
                        borderTiles.Where(t => t.yCoord <= corridorStart.yCoord + 2 &
                                               t.yCoord >= corridorStart.yCoord - 2).ToArray();
                    for (int j = 0; j < tilesToKill.Count(); j++)
                    {
                        borderTiles.Remove(tilesToKill[j]);
                    }
                }
                else
                {
                    Debug.Log(string.Format("Building corridor on x = {0}", corridorStart.xCoord));
                    for (int y = 0; y < tileMatrix.GetLength(1); y++)
                    {
                        tileMatrix[corridorStart.xCoord, y].HasTile = true;
                    }

                    var tilesToKill =
                        borderTiles.Where(t => t.xCoord <= corridorStart.xCoord + 2 &
                                               t.xCoord >= corridorStart.xCoord - 2).ToArray();
                    for(int j=0; j<tilesToKill.Count(); j++)
                    {
                        borderTiles.Remove(tilesToKill[j]);
                    }
                }

                
                initialCorridors--;
            }
        }
        else
        {
            foreach (var bt in borderTiles)
            {
                bt.HasTile = true;
            }
        }
    }
    
    void DrawBoard()
    {
        for (int x = 0; x < tileMatrix.GetLength(0); x++)
        {
            for (int y = 0; y < tileMatrix.GetLength(1); y++)
            {
                if (tileMatrix[x, y].HasTile)
                {
                    Instantiate(TilePf, new Vector3(y, 0, x), Quaternion.identity, this.transform);
                }
                else
                {
                    Instantiate(RoomPf, new Vector3(y, 0, x), Quaternion.identity, this.transform);
                }
            }
        }
    }
}
