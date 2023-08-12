public class PlayerInventory : ItemContainer
{
    private void Start()
    {
        LoadPlayerItems(Settings.playerInventoryKey);
    }
}