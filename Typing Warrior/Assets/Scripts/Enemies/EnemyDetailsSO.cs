using UnityEditorInternal;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Enemy/EnemyDetails", fileName = "_EnemyDetails")]
public class EnemyDetailsSO : ScriptableObject
{
    public string enemyName;
    public int health;
    public int damage;

    public RuntimeAnimatorController animatorController;
}