using UnityEngine;

public static class Settings
{
    public const string inventoryScene = "InventoryScene";
    public const string gameScene = "GameScene";
    public const string mainMenuScene = "MainMenu";

    public const string playerInventoryKey = "playerInventory";
    public const string playerEquipmentKey = "playerEquipment";
    public const string currentLevelKey = "currentLevel";

    public static int attackTrigger = Animator.StringToHash("AttackTrigger");

    public const int defaultNumberOfEnemies = 6;
    public const int numberOfLevelToAddEnemies = 10;
    public const int numberOfEnemiesToAdd = 2;
}