using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Enemy/EnemyDetails", fileName = "_EnemyDetails")]
public class EnemyDetailsSO : ScriptableObject
{
    public string enemyName;

    [Space(5)]
    public int health;

    [Space(5)]
    public int damage;
    public float delayBeforeAttack;

    [Space(5)]
    public RuntimeAnimatorController animatorController;
}