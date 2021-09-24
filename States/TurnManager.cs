

using UnityEngine;

[RequireComponent(typeof(Board))]
public sealed class TurnManager : MonoBehaviour
{
    public static TurnManager Instance;
    public State Current { get; private set; }

    private void Awake() {

        SetSingleton();
    }
    private void SetSingleton() {

        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }
    public void SetState (State state) {

        Current = state;
    }

}