

using System.Collections.Generic;
using UnityEngine;

public sealed class Knight : BasePiece, IPinnable
{
    public override string Name() {

        return "Knight";
    }
    public List<Vector2> ValidMoves() {

        return Behaviour.ValidMoves();
    }
    public bool IsPinned() {

        return false;
    }

    public Knight (Vector2 position, ColorProp color) : base(position, color) {

        this.Behaviour = new KnightBehaviour(this);
    }
}