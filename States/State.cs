


public abstract class State
{
    protected TurnManager turnManager;
    public abstract string Name();
    public abstract void Execute();

    public State (TurnManager turnManager) {

        this.turnManager = turnManager;
    }
}