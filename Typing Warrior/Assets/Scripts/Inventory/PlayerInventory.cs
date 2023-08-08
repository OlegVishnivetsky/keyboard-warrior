public class PlayerInventory : ItemContainer
{
    private void Start()
    {
        LoadPlayerInventoryItems(Settings.playerInventoryKey);
    }
}