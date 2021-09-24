

using UnityEngine;

public abstract class BasePiece
{
    public Vector2 Coordinates;
    public abstract string Name();
    public PieceBehaviour Behaviour;
    public ColorProp Color { get; }

    public BasePiece (Vector2 position, ColorProp color) {

        Color = color;
        Coordinates.x = position.x;
        Coordinates.y = position.y;
        Board.Instance.Pieces.Add(this);
    }

    public bool IsFriendly (BasePiece movingPiece) {

        return Color == movingPiece.Color ? true : false;
    }
}