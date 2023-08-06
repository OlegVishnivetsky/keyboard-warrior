using UnityEngine;

public class Enemy : MonoBehaviour
{
    [HideInInspector] public EnemyAppearanceTween appearanceTween;

    private string enemyWord;

    private void OnEnable()
    {
        enemyWord = WordCollection.Instance.GetRandomWordFromCollection();
    }

    public string GetEnemyWord() 
    { 
        return enemyWord; 
    }

    public void GenerateNewWord()
    {
        enemyWord = WordCollection.Instance.GetRandomWordFromCollection();
    }
}