

using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(SpriteRenderer))]
public sealed class PieceController : MonoBehaviour
{
    public BasePiece piece;
    private SpriteRenderer spriteRenderer;

    // Exposing for inspector.
    public ColorProp exposedColorProperty;
    public string exposedName;
    public Vector2 exposedCoordinates;

    private void Awake() {

        GetComponents();
    }
    public void SetPiece (BasePiece basePiece, Sprite sprite) {

        this.piece = basePiece;
        this.spriteRenderer.sprite = sprite;

        Rename();
        UpdateExposedFields();
    }
    private void GetComponents () {

        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    public void UpdateExposedFields() {

        exposedColorProperty = piece.Color;
        exposedName = piece.Name();
        exposedCoordinates = piece.Coordinates;
    }
    public void Rename() {

        gameObject.name = $"{piece.Color} - {piece.Name()}";
    }

    private void OnMouseDown() {

        if (PieceIsPinned()) {

            Debug.Log("This piece is pinned, Bro!");
            return;
        }

        piece.Behaviour.ValidMoves();
    }

    private Vector2 LocateFriendlyKing() {

        Vector2 position = piece.Color == 
        ColorProp.Black ? Board.Instance.BlackKingPosition : Board.Instance.WhiteKingPosition;
        return position;
    }
    private bool PieceIsPinned () {

        if (piece is IPinnable == false) return false;
        var result = Rules.PinCheck(piece, LocateFriendlyKing());
        Debug.Log("This Piece is pinned: " + result);
        return result;
    }
}
