using System;

public static class StaticEventHandler
{
    public static event Action OnLevelCompleted;

    public static void InvokeLevelCompletedEvent()
    {
        OnLevelCompleted?.Invoke();
    }

    public static event Action OnPlayerLost;

    public static void InvokePlayerLostEvent()
    {
        OnPlayerLost?.Invoke();
    }
}