

using UnityEngine;

public sealed class Square : MonoBehaviour
{

    public Vector2 Coordinates;

    public void SetCoordinates (Vector2 vector) {

        Coordinates = vector;
        gameObject.name = $"Square - {Coordinates.x}/{Coordinates.y}";
    }
}