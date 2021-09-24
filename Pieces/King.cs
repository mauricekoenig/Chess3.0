


using System.Collections.Generic;
using UnityEngine;

public sealed class King : BasePiece, ICheckable
{
    public override string Name() {

        return "King";
    }
    public List<Vector2> ValidMoves() {

        return Behaviour.ValidMoves();
    }
    public bool IsChecked() {

        return false;
    }

    public King (Vector2 position, ColorProp color) : base(position, color) {

        this.Behaviour = new KingBehaviour(this);
    }
}