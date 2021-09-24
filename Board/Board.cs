
using UnityEngine;
using System.Collections.Generic;

public sealed class Board : MonoBehaviour
{
    public static Board Instance;
    public List<BasePiece> Pieces;
    private GameObject Square;
    private GameObject PieceControllerPrefab;
    public Dictionary<string, PieceController> Fields;
    public List<Square> IndividualSquares;
    public Dictionary<string, Sprite> Sprites;
    private ColorTheme colorTheme;

    // ref to kings
    public Vector2 BlackKingPosition { get; set; }
    public Vector2 WhiteKingPosition { get; set; }
    public PieceController BlackKingController { get; set; }
    public PieceController WhiteKingController { get; set; }

    private void Awake() {

        SetSingleton();
    }
    private void Start() {

        Initialize();
        SetColorTheme(new GrayColorTheme());
        LoadSprites();
        CreateBoard();
        CreateRuyLopezPinVariation();

    }
    private void CreateBoard() {

        var startColor = colorTheme.Color();

        for (var i = 1; i <= 8; i++) {

            for (int j = 1; j <= 8; j++) {

                var square = Instantiate(Square, new Vector3(i, j, 0), Quaternion.identity);
                var squareSprite = square.GetComponent<SpriteRenderer>();
                var squareCode = square.GetComponent<Square>();
                squareCode.SetCoordinates(new Vector2(i, j));
                squareSprite.color = startColor;

                startColor = startColor == colorTheme.Color() ? Color.white : colorTheme.Color();
                Fields.Add(Util.Translate(squareCode), null);
                IndividualSquares.Add(squareCode);
            }

            startColor = startColor == colorTheme.Color() ? Color.white : colorTheme.Color();
        }
    }
    private void Initialize() {

        Pieces = new List<BasePiece>();
        Sprites = new Dictionary<string, Sprite>();
        Fields = new Dictionary<string, PieceController>();
        IndividualSquares = new List<Square>();
        Square = Resources.Load<GameObject>("SquarePrefab");
        PieceControllerPrefab = Resources.Load<GameObject>("PieceControllerPrefab");
    }
    private void SetSingleton() {

        if (Instance == null) Instance = this;
        else Destroy(gameObject);

    }
    private void LoadSprites() {

        Sprites.Add("White King", Resources.Load<Sprite>("Sprites/white_king"));
        Sprites.Add("White Queen", Resources.Load<Sprite>("Sprites/white_queen"));
        Sprites.Add("White Knight", Resources.Load<Sprite>("Sprites/white_knight"));
        Sprites.Add("White Bishop", Resources.Load<Sprite>("Sprites/white_bishop"));
        Sprites.Add("White Rook", Resources.Load<Sprite>("Sprites/white_rook"));
        Sprites.Add("White Pawn", Resources.Load<Sprite>("Sprites/white_pawn"));

        Sprites.Add("Black King", Resources.Load<Sprite>("Sprites/black_king"));
        Sprites.Add("Black Queen", Resources.Load<Sprite>("Sprites/black_queen"));
        Sprites.Add("Black Knight", Resources.Load<Sprite>("Sprites/black_knight"));
        Sprites.Add("Black Bishop", Resources.Load<Sprite>("Sprites/black_bishop"));
        Sprites.Add("Black Rook", Resources.Load<Sprite>("Sprites/black_rook"));
        Sprites.Add("Black Pawn", Resources.Load<Sprite>("Sprites/black_pawn"));
    }
    private void SetColorTheme(ColorTheme colorTheme) {

        this.colorTheme = colorTheme;
    }
    private void UpdateColorTheme(ColorTheme colorTheme) {

        foreach (var s in IndividualSquares) {

            var sr = s.GetComponent<SpriteRenderer>();

            if (sr.color != Color.white)
                sr.color = colorTheme.Color();
        }
    }
    private void CreateCustom(PieceType pieceType, ColorProp color, string notation) {

        var coordinates = Util.DeTranslate(notation);
        string spriteName;
        var upperNotation = notation.ToUpper();

        if (pieceType == PieceType.King) {

            var king = Instantiate(PieceControllerPrefab, coordinates, Quaternion.identity);
            king.transform.localScale = Constants.PieceScale;
            king.GetComponent<SpriteRenderer>().sortingOrder = Constants.PieceSortingOrder;
            var kingController = king.GetComponent<PieceController>();

            if (color == ColorProp.Black) 
            spriteName = "Black King";

            else
            spriteName = "White King";

            kingController.SetPiece(new King(coordinates, color), Sprites[spriteName]);

            if (color == ColorProp.Black) {

                BlackKingPosition = kingController.piece.Coordinates;
                BlackKingController = kingController;
            } 
            
            else if (color == ColorProp.White) {

                WhiteKingPosition = kingController.piece.Coordinates;
                WhiteKingController = kingController;
            }

            Fields[upperNotation] = kingController;
        }
        else if (pieceType == PieceType.Queen) {

            var queen = Instantiate(PieceControllerPrefab, coordinates, Quaternion.identity);
            var queenController = queen.GetComponent<PieceController>();
            queen.transform.localScale = Constants.PieceScale;
            queen.GetComponent<SpriteRenderer>().sortingOrder = Constants.PieceSortingOrder;

            if (color == ColorProp.Black)
            spriteName = "Black Queen";

            else
            spriteName = "White Queen";

            queenController.SetPiece(new Queen(coordinates, color), Sprites[spriteName]);
            Fields[upperNotation] = queenController;
        }
        else if (pieceType == PieceType.Knight) {

            var knight = Instantiate(PieceControllerPrefab, coordinates, Quaternion.identity);
            var knightController = knight.GetComponent<PieceController>();
            knight.transform.localScale = Constants.PieceScale;
            knight.GetComponent<SpriteRenderer>().sortingOrder = Constants.PieceSortingOrder;

            if (color == ColorProp.Black)
                spriteName = "Black Knight";

            else
            spriteName = "White Knight";

            knightController.SetPiece(new Knight(coordinates, color), Sprites[spriteName]);
            Fields[upperNotation] = knightController;
        }
        else if (pieceType == PieceType.Bishop) {

            var bishop = Instantiate(PieceControllerPrefab, coordinates, Quaternion.identity);
            bishop.transform.localScale = Constants.PieceScale;
            bishop.GetComponent<SpriteRenderer>().sortingOrder = Constants.PieceSortingOrder;
            var bishopController = bishop.GetComponent<PieceController>();

            if (color == ColorProp.Black)
                spriteName = "Black Bishop";

            else
                spriteName = "White Bishop";

            bishopController.SetPiece(new Bishop(coordinates, color), Sprites[spriteName]);
            Fields[upperNotation] = bishopController;
        }
        else if (pieceType == PieceType.Rook) {

            var rook = Instantiate(PieceControllerPrefab, coordinates, Quaternion.identity);
            var rookController = rook.GetComponent<PieceController>();
            rook.transform.localScale = Constants.PieceScale;
            rook.GetComponent<SpriteRenderer>().sortingOrder = Constants.PieceSortingOrder;

            if (color == ColorProp.Black)
                spriteName = "Black Rook";

            else
                spriteName = "White Rook";

            rookController.SetPiece(new Rook(coordinates, color), Sprites[spriteName]);
            Fields[upperNotation] = rookController;
        }
        else if (pieceType == PieceType.Pawn) {

            var pawn = Instantiate(PieceControllerPrefab, coordinates, Quaternion.identity);
            var pawnController = pawn.GetComponent<PieceController>();
            pawn.transform.localScale = Constants.PieceScale;
            pawn.GetComponent<SpriteRenderer>().sortingOrder = Constants.PieceSortingOrder;

            if (color == ColorProp.Black)
                spriteName = "Black Pawn";

            else
                spriteName = "White Pawn";

            pawnController.SetPiece(new Pawn(coordinates, color), Sprites[spriteName]);
            Fields[upperNotation] = pawnController;
        }
        else return;
    }
    private void Update() {

        if (Input.GetKeyDown(KeyCode.G)) {

            UpdateColorTheme(new GrayColorTheme());
        } else if (Input.GetKeyDown(KeyCode.B)) {

            UpdateColorTheme(new BrownColorTheme());
        }
    }

    private void CreateRuyLopezPinVariation() {

        CreateCustom(PieceType.King, ColorProp.White, "e1");
        CreateCustom(PieceType.King, ColorProp.Black, "e8");

        CreateCustom(PieceType.Pawn, ColorProp.White, "a2");
        CreateCustom(PieceType.Pawn, ColorProp.White, "b2");
        CreateCustom(PieceType.Pawn, ColorProp.White, "c2");
        CreateCustom(PieceType.Pawn, ColorProp.White, "d2");
        CreateCustom(PieceType.Pawn, ColorProp.White, "e4");
        CreateCustom(PieceType.Pawn, ColorProp.White, "f2");
        CreateCustom(PieceType.Pawn, ColorProp.White, "g2");
        CreateCustom(PieceType.Pawn, ColorProp.White, "h2");

        CreateCustom(PieceType.Pawn, ColorProp.Black, "a7");
        CreateCustom(PieceType.Pawn, ColorProp.Black, "b7");
        CreateCustom(PieceType.Pawn, ColorProp.Black, "c7");
        CreateCustom(PieceType.Pawn, ColorProp.Black, "d7");
        CreateCustom(PieceType.Pawn, ColorProp.Black, "e5");
        CreateCustom(PieceType.Pawn, ColorProp.Black, "f7");
        CreateCustom(PieceType.Pawn, ColorProp.Black, "g7");
        CreateCustom(PieceType.Pawn, ColorProp.Black, "h7");

        CreateCustom(PieceType.Knight, ColorProp.White, "f3");
        CreateCustom(PieceType.Knight, ColorProp.Black, "c6");
        CreateCustom(PieceType.Knight, ColorProp.Black, "g8");
        CreateCustom(PieceType.Knight, ColorProp.White, "b1");

        CreateCustom(PieceType.Bishop, ColorProp.White, "b5");
        CreateCustom(PieceType.Bishop, ColorProp.White, "c1");
        CreateCustom(PieceType.Bishop, ColorProp.Black, "c8");
        CreateCustom(PieceType.Bishop, ColorProp.Black, "f8");

        CreateCustom(PieceType.Rook, ColorProp.White, "a1");
        CreateCustom(PieceType.Rook, ColorProp.White, "h1");
        CreateCustom(PieceType.Rook, ColorProp.Black, "a8");
        CreateCustom(PieceType.Rook, ColorProp.Black, "h8");

        CreateCustom(PieceType.Queen, ColorProp.White, "d1");
        CreateCustom(PieceType.Queen, ColorProp.Black, "d8");

    }
    private void CreateItalianGame() {


        CreateCustom(PieceType.King, ColorProp.White, "e1");
        CreateCustom(PieceType.King, ColorProp.Black, "e8");

        CreateCustom(PieceType.Pawn, ColorProp.White, "a2");
        CreateCustom(PieceType.Pawn, ColorProp.White, "b2");
        CreateCustom(PieceType.Pawn, ColorProp.White, "c2");
        CreateCustom(PieceType.Pawn, ColorProp.White, "d2");
        CreateCustom(PieceType.Pawn, ColorProp.White, "e4");
        CreateCustom(PieceType.Pawn, ColorProp.White, "f2");
        CreateCustom(PieceType.Pawn, ColorProp.White, "g2");
        CreateCustom(PieceType.Pawn, ColorProp.White, "h2");

        CreateCustom(PieceType.Pawn, ColorProp.Black, "a7");
        CreateCustom(PieceType.Pawn, ColorProp.Black, "b7");
        CreateCustom(PieceType.Pawn, ColorProp.Black, "c7");
        CreateCustom(PieceType.Pawn, ColorProp.Black, "d7");
        CreateCustom(PieceType.Pawn, ColorProp.Black, "e5");
        CreateCustom(PieceType.Pawn, ColorProp.Black, "f7");
        CreateCustom(PieceType.Pawn, ColorProp.Black, "g7");
        CreateCustom(PieceType.Pawn, ColorProp.Black, "h7");

        CreateCustom(PieceType.Knight, ColorProp.White, "f3");
        CreateCustom(PieceType.Knight, ColorProp.Black, "c6");
        CreateCustom(PieceType.Knight, ColorProp.Black, "g8");
        CreateCustom(PieceType.Knight, ColorProp.White, "b1");

        CreateCustom(PieceType.Bishop, ColorProp.White, "c4");
        CreateCustom(PieceType.Bishop, ColorProp.White, "c1");
        CreateCustom(PieceType.Bishop, ColorProp.Black, "c8");
        CreateCustom(PieceType.Bishop, ColorProp.Black, "c5");

        CreateCustom(PieceType.Rook, ColorProp.White, "a1");
        CreateCustom(PieceType.Rook, ColorProp.White, "h1");
        CreateCustom(PieceType.Rook, ColorProp.Black, "a8");
        CreateCustom(PieceType.Rook, ColorProp.Black, "h8");

        CreateCustom(PieceType.Queen, ColorProp.White, "d1");
        CreateCustom(PieceType.Queen, ColorProp.Black, "d8");
    }
    private void CreateSicilianDefense() {

        CreateCustom(PieceType.King, ColorProp.White, "e1");
        CreateCustom(PieceType.King, ColorProp.Black, "e8");

        CreateCustom(PieceType.Pawn, ColorProp.White, "a2");
        CreateCustom(PieceType.Pawn, ColorProp.White, "b2");
        CreateCustom(PieceType.Pawn, ColorProp.White, "c2");
        CreateCustom(PieceType.Pawn, ColorProp.White, "d2");
        CreateCustom(PieceType.Pawn, ColorProp.White, "e4");
        CreateCustom(PieceType.Pawn, ColorProp.White, "f2");
        CreateCustom(PieceType.Pawn, ColorProp.White, "g2");
        CreateCustom(PieceType.Pawn, ColorProp.White, "h2");

        CreateCustom(PieceType.Pawn, ColorProp.Black, "a7");
        CreateCustom(PieceType.Pawn, ColorProp.Black, "b7");
        CreateCustom(PieceType.Pawn, ColorProp.Black, "c5");
        CreateCustom(PieceType.Pawn, ColorProp.Black, "d7");
        CreateCustom(PieceType.Pawn, ColorProp.Black, "e7");
        CreateCustom(PieceType.Pawn, ColorProp.Black, "f7");
        CreateCustom(PieceType.Pawn, ColorProp.Black, "g7");
        CreateCustom(PieceType.Pawn, ColorProp.Black, "h7");

        CreateCustom(PieceType.Knight, ColorProp.White, "g1");
        CreateCustom(PieceType.Knight, ColorProp.Black, "b8");
        CreateCustom(PieceType.Knight, ColorProp.Black, "g8");
        CreateCustom(PieceType.Knight, ColorProp.White, "b1");

        CreateCustom(PieceType.Bishop, ColorProp.White, "f1");
        CreateCustom(PieceType.Bishop, ColorProp.White, "c1");
        CreateCustom(PieceType.Bishop, ColorProp.Black, "f8");
        CreateCustom(PieceType.Bishop, ColorProp.Black, "c8");

        CreateCustom(PieceType.Rook, ColorProp.White, "a1");
        CreateCustom(PieceType.Rook, ColorProp.White, "h1");
        CreateCustom(PieceType.Rook, ColorProp.Black, "a8");
        CreateCustom(PieceType.Rook, ColorProp.Black, "h8");

        CreateCustom(PieceType.Queen, ColorProp.White, "d1");
        CreateCustom(PieceType.Queen, ColorProp.Black, "a5");
    }
}