
using System;

public static class PlayerEntityEventBus
{
    public static event EventHandler PlayerMovementEventHandler;
    
    public static void PlayerMovementListener()
    {
        PlayerMovementEventHandler?.Invoke(null, EventArgs.Empty);
    }

}
