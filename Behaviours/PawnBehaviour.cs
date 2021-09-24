



using System.Collections.Generic;
using UnityEngine;

public sealed class PawnBehaviour : PieceBehaviour
{
    public PawnBehaviour (BasePiece basePiece) : base(basePiece) {

        directions = new Vector2[] { }; 
    }

    public override List<Vector2> RawMoves() {

        var valid = new List<Vector2>();

        for (int i = 0; i < directions.Length; i++) {

            for (int j = 1; j <= 7; j++) {

                var newCoordinates = piece.Coordinates + (directions[i] * j);

                if (newCoordinates.x > 8) break;
                if (newCoordinates.x < 1) break;
                if (newCoordinates.y > 8) break;
                if (newCoordinates.y < 1) break;

                valid.Add(newCoordinates);
            }
        }

        return valid;
    }

    public override List<Vector2> ValidMoves() {

        return new List<Vector2>();
    }
}