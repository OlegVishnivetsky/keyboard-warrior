public class PlayerInventory : ItemContainer
{
    private void Start()
    {
        LoadPlayerItems(Settings.playerInventoryKey);
    }

    private void OnApplicationQuit()
    {
        SavePlayerItems(Settings.playerInventoryKey);
    }
}