using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = System.Object;

public class TilePosition
{
    int positionX;
    int positionY;

    public TilePosition(int x, int y)
    {
        this.positionX = x;
        this.positionY = y;
    }

    public int getPositionX()
    {
        return positionX;
    }

    public int getPositionY()
    {
        return positionY;
    }

    public void setPositionX(int positionX)
    {
        this.positionX = positionX;
    }

    public void setPositionY(int positionY)
    {
        this.positionY = positionY;
    }

    public override bool Equals(Object obj)
    {
        TilePosition otherPos = obj as TilePosition;
        return positionX == otherPos.getPositionX()
            && positionY == otherPos.getPositionY();
    }
}
