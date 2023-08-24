using System.Collections.Generic;
using UnityEngine;

public class GameResources : SingletonMonobehaviour<GameResources>
{
    [Header("ENEMY MATERIALS")]
    public List<Material> enemyMaterials;

    [Header("SOUND EFFECTS")]
    public SoundEffectSO playerTakeDamageSound;
    public SoundEffectSO playerAttackSound;
    public SoundEffectSO clickSound;

    [Header("MUSIC")]
    public AudioClip mainMenuMusic;
    public List<AudioClip> gameSceneMusicList;
}