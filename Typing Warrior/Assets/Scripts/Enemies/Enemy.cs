using UnityEngine;

public class Enemy : MonoBehaviour
{
    private string enemyWord;

    private void OnEnable()
    {
        enemyWord = WordCollection.Instance.GetRandomWordFromCollection();
    }

    public string GetEnemyWord() 
    { 
        return enemyWord; 
    }
}