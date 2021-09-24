

using System.Collections.Generic;
using UnityEngine;

public sealed class Queen : BasePiece, IPinnable, ICanPin
{
    public override string Name() {

        return "Queen";
    }
    public List<Vector2> ValidMoves() {

        return Behaviour.ValidMoves();
    }
    public bool IsPinned() {

        return false;
    }

    public Queen (Vector2 position, ColorProp color) : base(position, color) {

        this.Behaviour = new QueenBehaviour(this);
    }
}