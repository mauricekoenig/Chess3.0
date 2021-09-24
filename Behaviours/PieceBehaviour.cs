

using System.Collections.Generic;
using UnityEngine;

public abstract class PieceBehaviour
{
    protected BasePiece piece;
    protected Vector2[] directions; 
    public PieceBehaviour (BasePiece piece) {

        this.piece = piece;
    }

    public abstract List<Vector2> ValidMoves();
    public abstract List<Vector2> RawMoves();
}