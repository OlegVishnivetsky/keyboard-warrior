using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Enemy/EnemyDetails", fileName = "_EnemyDetails")]
public class EnemyDetailsSO : ScriptableObject
{
    public string enemyName;

    [Space(5)]
    public int baseHealth;

    [Space(5)]
    public int baseDamage;
    public float delayBeforeAttack;

    [Space(5)]
    public RuntimeAnimatorController animatorController;
}