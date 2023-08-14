using System.Collections.Generic;
using UnityEngine;

public class GameResources : SingletonMonobehaviour<GameResources>
{
    [Header("ENEMY MATERIALS")]
    public List<Material> enemyMaterials;

    [Header("SOUND EFFECTS")]
    public AudioClip playerTakeDamageSound;
    public AudioClip playerAttackSound;

    [Header("MUSIC")]
    public AudioClip mainMenuMusic;
    public AudioClip levelCompleteMusic;
    public List<AudioClip> gameSceneMusicList;
}