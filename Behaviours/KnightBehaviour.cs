

using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public sealed class KnightBehaviour: PieceBehaviour
{
    public KnightBehaviour (BasePiece basePiece) : base(basePiece) {

        directions = new Vector2[] {

            // left
            new Vector2(-2, -1),
            new Vector2(-2, 1),
            new Vector2(-1, 2),
            new Vector2(-1, -2),

            // up
            new Vector2(1, 2),
            new Vector2(-1, 2),
            new Vector2(2, 1),
            new Vector2(-2, 1),

            // right
            new Vector2(2, 1),
            new Vector2(2, -1),
            new Vector2(1, 2),
            new Vector2(1, -2),

            // down
            new Vector2(-1, 2),
            new Vector2(1, 2),
            new Vector2(-2, 1),
            new Vector2(2, 1)
            
            // 7, 7
            // + 2, 1

        };
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

        var valid = new List<Vector2>();

        for (int i = 0; i < directions.Length; i++) {

            var currentCoordinates = piece.Coordinates;
            var newCoordinates = currentCoordinates + directions[i];

            if (newCoordinates.x > 8) continue;
            if (newCoordinates.x < 1) continue;
            if (newCoordinates.y > 8) continue;
            if (newCoordinates.y < 1) continue;

            if (Board.Instance.Fields[Util.Translate(newCoordinates)] == null) {

                valid.Add(newCoordinates);
                continue;
            }
        }

        return valid;
    }
}