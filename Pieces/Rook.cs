

using System.Collections.Generic;
using UnityEngine;

public sealed class Rook : BasePiece, IPinnable, ICanPin
{

    public override string Name() {

        return "Rook";
    }
    public List<Vector2> ValidMoves() {

        return Behaviour.ValidMoves();
    }
    public bool IsPinned() {

        return false;
    }

    public Rook (Vector2 position, ColorProp color) : base(position, color) {

        this.Behaviour = new RookBehaviour(this);
    }
}