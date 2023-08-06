[System.Serializable]
public class ItemStatModification
{
    public int value;
    public StatToModify statToModify;
    public ModificationType modificationType;

    public string GetItemStatModificationDescription()
    {
        if (modificationType == ModificationType.Default)
        {
            switch (statToModify) 
            {
                case StatToModify.Health:
                    return $"+{value} to health";

                case StatToModify.Damage:
                    return $"+{value} to damage";

                case StatToModify.Armor:
                    return $"+{value} to armor";

                default:
                    break;
            }
        }
        else if (modificationType == ModificationType.Percent)
        {
            switch (statToModify)
            {
                case StatToModify.Health:
                    return $"+{value}% to health";

                case StatToModify.Damage:
                    return $"+{value}% to damage";

                case StatToModify.Armor:
                    return $"+{value}% to armor";

                default:
                    break;
            }
        }

        return null;
    }
}