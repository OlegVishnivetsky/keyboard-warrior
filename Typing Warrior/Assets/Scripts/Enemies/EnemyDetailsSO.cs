using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Enemy/EnemyDetails", fileName = "_EnemyDetails")]
public class EnemyDetailsSO : ScriptableObject
{
    public int health;
    public int damage;
    public string enemyName;
}