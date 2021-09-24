



using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public sealed class KingBehaviour : PieceBehaviour
{
    public KingBehaviour(BasePiece basePiece) : base(basePiece) {

        directions = new Vector2[] {

            new Vector2(1, 0),
            new Vector2(-1, 0),
            new Vector2(0, 1),
            new Vector2(0, -1),

            new Vector2(1, 1),
            new Vector2(-1, 1),
            new Vector2(1, -1),
            new Vector2(-1, -1)
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

            for (int j = 1; j < 2; j++) {

                var newCoordinates = piece.Coordinates + (directions[i] * j);

                if (newCoordinates.x > 8) break;
                if (newCoordinates.x < 1) break;
                if (newCoordinates.y > 8) break;
                if (newCoordinates.y < 1) break;

                var enemyKingController = piece.Color == ColorProp.White ? Board.Instance.BlackKingController
                : Board.Instance.WhiteKingController;
                var enemyKingBehaviour = enemyKingController.piece.Behaviour as KingBehaviour;
                var enemyKingRawMoves = enemyKingBehaviour.RawMoves();

                if (enemyKingRawMoves.Contains(newCoordinates))
                    break;

                if (Rules.KingWouldBeChecked(piece.Color, newCoordinates))
                    break;

                var notation = Util.Translate(newCoordinates);
                var newSquare = Board.Instance.Fields[notation];

                if (newSquare == null) {

                    valid.Add(newCoordinates);
                    break;
                }

                if (!newSquare.piece.IsFriendly(piece)) {

                    valid.Add(newCoordinates);
                    break;
                }

                if (newSquare.piece.IsFriendly(piece)) break;
            }
        }

        // Debug
        foreach (var s in valid) {

            Board.Instance.IndividualSquares.Where(x => x.Coordinates.x == s.x && x.Coordinates.y == s.y).Single().GetComponent<SpriteRenderer>().color = Color.red;
        }

        return valid;
    }


}