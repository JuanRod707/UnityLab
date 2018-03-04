using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class BoardInfo
{
    public int MinHeight;
    public int MaxHeight;
    public int MinWidth;
    public int MaxWidth;

    public int MinCorridors;
    public int MaxCorridors;

    public int MinRoomSize;

    public int MinCorridorLength;
    public int MaxCorridorLength;
    public int ForkChance;
}
