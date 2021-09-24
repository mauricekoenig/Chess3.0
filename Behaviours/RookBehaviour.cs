﻿

using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public sealed class RookBehaviour : PieceBehaviour
{
    public RookBehaviour (BasePiece basePiece) : base(basePiece) {

        directions = new Vector2[] {

            new Vector2(1, 0),
            new Vector2(-1, 0),
            new Vector2(0, 1),
            new Vector2(0, -1)
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

            for (int j = 1; j <= 7; j++) {

                var newCoordinates = piece.Coordinates + (directions[i] * j);

                if (newCoordinates.x > 8) break;
                if (newCoordinates.x < 1) break;
                if (newCoordinates.y > 8) break;
                if (newCoordinates.y < 1) break;

                var notation = Util.Translate(newCoordinates);
                var newSquare = Board.Instance.Fields[notation];

                if (newSquare == null) {

                    valid.Add(newCoordinates);
                    continue;
                }

                if (!newSquare.piece.IsFriendly(piece)) {

                    valid.Add(newCoordinates);
                    break;
                }

                if (newSquare.piece.IsFriendly(piece)) break;
            }
        }

        return valid;
    }
}