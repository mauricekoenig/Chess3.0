


using System.Collections.Generic;
using UnityEngine;

public sealed class Pawn : BasePiece, IPinnable
{
    public bool Moved2Squares { get; set; }
    public bool EnPassantable { get; set; }

    public override string Name() {

        return "Pawn";
    }
    public List<Vector2> ValidMoves() {

        return Behaviour.ValidMoves();
    }
    public bool IsPinned() {

        return false;
    }

    public Pawn(Vector2 position, ColorProp color) : base(position, color) {

        this.Behaviour = new PawnBehaviour(this);
    }
}