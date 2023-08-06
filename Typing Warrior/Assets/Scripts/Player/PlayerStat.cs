using UnityEngine;

[System.Serializable]
public class PlayerStat
{
    [SerializeField] private int value;

    public PlayerStat(int value)
    {
        this.value = value;
    }

    public int GetValue() 
    { 
        return value; 
    }

    public void ModifyValue(int value, ModificationType modificationType)
    {
        if (modificationType == ModificationType.Default)
        {
            this.value += value;
        }
        else if (modificationType == ModificationType.Percent)
        {
            AddPercentValue(value);
        }
    }    

    public void AddPercentValue(int percent)
    {
        float valueToAdd = value * ((float)percent / 100);

        value += (int)valueToAdd;
    }
}