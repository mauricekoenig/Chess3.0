




using UnityEngine;

public static class Util
{

    public static readonly string[] WhitePawnStartNotations = new string[] { "A2", "B2", "C2", "D2", "E2", "F2", "G2", "H2" };
    public static readonly string[] BlackPawnStartNotations = new string[] { "A7", "B7", "C7", "D7", "E7", "F7", "G7", "H7" };

    public static string Translate (Square square) {

        if (square.Coordinates.x == 1)
            return $"{"A"}{square.Coordinates.y}";

        if (square.Coordinates.x == 2)
            return $"{"B"}{square.Coordinates.y}";

        if (square.Coordinates.x == 3)
            return $"{"C"}{square.Coordinates.y}";

        if (square.Coordinates.x == 4)
            return $"{"D"}{square.Coordinates.y}";

        if (square.Coordinates.x == 5)
            return $"{"E"}{square.Coordinates.y}";

        if (square.Coordinates.x == 6)
            return $"{"F"}{square.Coordinates.y}";

        if (square.Coordinates.x == 7)
            return $"{"G"}{square.Coordinates.y}";

        if (square.Coordinates.x == 8)
            return $"{"H"}{square.Coordinates.y}";

        return null;

    }
    public static string Translate (Vector2 vector) {

        if (vector.x == 1)
            return $"{"A"}{vector.y}";

        if (vector.x == 2)
            return $"{"B"}{vector.y}";

        if (vector.x == 3)
            return $"{"C"}{vector.y}";

        if (vector.x == 4)
            return $"{"D"}{vector.y}";

        if (vector.x == 5)
            return $"{"E"}{vector.y}";

        if (vector.x == 6)
            return $"{"F"}{vector.y}";

        if (vector.x == 7)
            return $"{"G"}{vector.y}";

        if (vector.x == 8)
            return $"{"H"}{vector.y}";

        return null;
    }

    public static Vector2 DeTranslate (string notation) {

        switch (notation.ToUpper()) {

            case "A1":
                return new Vector2(1, 1);
            case "A2":
                return new Vector2(1, 2);
            case "A3":
                return new Vector2(1, 3);
            case "A4":
                return new Vector2(1, 4);
            case "A5":
                return new Vector2(1, 5);
            case "A6":
                return new Vector2(1, 6);
            case "A7":
                return new Vector2(1, 7);
            case "A8":
                return new Vector2(1, 8);

            case "B1":
                return new Vector2(2, 1);
            case "B2":
                return new Vector2(2, 2);
            case "B3":
                return new Vector2(2, 3);
            case "B4":
                return new Vector2(2, 4);
            case "B5":
                return new Vector2(2, 5);
            case "B6":
                return new Vector2(2, 6);
            case "B7":
                return new Vector2(2, 7);
            case "B8":
                return new Vector2(2, 8);

            case "C1":
                return new Vector2(3, 1);
            case "C2":
                return new Vector2(3, 2);
            case "C3":
                return new Vector2(3, 3);
            case "C4":
                return new Vector2(3, 4);
            case "C5":
                return new Vector2(3, 5);
            case "C6":
                return new Vector2(3, 6);
            case "C7":
                return new Vector2(3, 7);
            case "C8":
                return new Vector2(3, 8);

            case "D1":
                return new Vector2(4, 1);
            case "D2":
                return new Vector2(4, 2);
            case "D3":
                return new Vector2(4, 3);
            case "D4":
                return new Vector2(4, 4);
            case "D5":
                return new Vector2(4, 5);
            case "D6":
                return new Vector2(4, 6);
            case "D7":
                return new Vector2(4, 7);
            case "D8":
                return new Vector2(4, 8);

            case "E1":
                return new Vector2(5, 1);
            case "E2":
                return new Vector2(5, 2);
            case "E3":
                return new Vector2(5, 3);
            case "E4":
                return new Vector2(5, 4);
            case "E5":
                return new Vector2(5, 5);
            case "E6":
                return new Vector2(5, 6);
            case "E7":
                return new Vector2(5, 7);
            case "E8":
                return new Vector2(5, 8);

            case "F1":
                return new Vector2(6, 1);
            case "F2":
                return new Vector2(6, 2);
            case "F3":
                return new Vector2(6, 3);
            case "F4":
                return new Vector2(6, 4);
            case "F5":
                return new Vector2(6, 5);
            case "F6":
                return new Vector2(6, 6);
            case "F7":
                return new Vector2(6, 7);
            case "F8":
                return new Vector2(6, 8);

            case "G1":
                return new Vector2(7, 1);
            case "G2":
                return new Vector2(7, 2);
            case "G3":
                return new Vector2(7, 3);
            case "G4":
                return new Vector2(7, 4);
            case "G5":
                return new Vector2(7, 5);
            case "G6":
                return new Vector2(7, 6);
            case "G7":
                return new Vector2(7, 7);
            case "G8":
                return new Vector2(7, 8);

            case "H1":
                return new Vector2(8, 1);
            case "H2":
                return new Vector2(8, 2);
            case "H3":
                return new Vector2(8, 3);
            case "H4":
                return new Vector2(8, 4);
            case "H5":
                return new Vector2(8, 5);
            case "H6":
                return new Vector2(8, 6);
            case "H7":
                return new Vector2(8, 7);
            case "H8":
                return new Vector2(8, 8);

            default:
                return Vector2.zero;
        }
    }

}