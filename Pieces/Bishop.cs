

using System.Collections.Generic;
using UnityEngine;

public sealed class Bishop : BasePiece, IPinnable, ICanPin
{
    public override string Name() {

        return "Bishop";
    }
    public List<Vector2> ValidMoves() {

        return Behaviour.ValidMoves();
    }
    public bool IsPinned() {

        return false;
    }

    public Bishop (Vector2 position, ColorProp color) : base(position, color) {

        this.Behaviour = new BishopBehaviour(this);
    }
}