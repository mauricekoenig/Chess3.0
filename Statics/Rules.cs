




using System.Linq;
using UnityEngine;

public static class Rules
{
    public static bool PinCheck (BasePiece checkedPiece, Vector2 friendlyKingPosition) {

        var enemiesColor = checkedPiece.Color == ColorProp.White ? ColorProp.Black : ColorProp.White;
        var enemies = Board.Instance.Pieces.Where(x => x.Color == enemiesColor && x is ICanPin);

        foreach (var enemy in enemies) {

            var rawMoves = enemy.Behaviour.RawMoves();
            if (!rawMoves.Contains(friendlyKingPosition) && !rawMoves.Contains(checkedPiece.Coordinates))
            continue;

            var direction = friendlyKingPosition - enemy.Coordinates;
            var dirNormalized = direction.normalized;

            dirNormalized.x = Mathf.Round(dirNormalized.x);
            dirNormalized.y = Mathf.Round(dirNormalized.y);

            for (int i = 1; i <= Mathf.Abs(direction.x); i++) {

                var newCoordinates = enemy.Coordinates + (dirNormalized * i);
                if (checkedPiece.Coordinates == newCoordinates)
                    return true;
            }
        }

        return false;
    }

    public static bool KingWouldBeChecked (ColorProp colorProperty, Vector2 desiredPosition) {

        var king = colorProperty == ColorProp.White ? Board.Instance.WhiteKingController : Board.Instance.BlackKingController;
        var enemyColor = colorProperty == ColorProp.White ? ColorProp.Black : ColorProp.White;
        var oppositeColorPieces = Board.Instance.Pieces.Where(x => x.Color == enemyColor && x.Name() != "King");

        foreach (var piece in oppositeColorPieces) {

            var enemySquares = piece.Behaviour.ValidMoves();

            if (enemySquares.Contains(desiredPosition))
            return true;
        }

        return false;
    }
}