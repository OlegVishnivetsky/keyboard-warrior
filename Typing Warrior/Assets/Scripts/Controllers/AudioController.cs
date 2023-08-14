using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioController : SingletonMonobehaviour<AudioController>
{
    [SerializeField] private AudioSource musicAudioSource;
    [SerializeField] private AudioSource soundEffectsAudioSource;

    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        switch (SceneManager.GetActiveScene().name)
        {
            case Settings.gameScene:
                PlayRandomBattleMusic();
                break;

            case Settings.mainMenuScene:
                ChangeMusicClipAndPlay(GameResources.Instance.mainMenuMusic);
                break;

            default:
                break;
        }

    }

    public void PlaySoundEffect(AudioClip soundEffect)
    {
        soundEffectsAudioSource.PlayOneShot(soundEffect);
    }

    public void PlayRandomBattleMusic()
    {
        int randomNumber = Random.Range(0, GameResources.Instance.gameSceneMusicList.Count);
        AudioClip gameSceneClip = GameResources.Instance.gameSceneMusicList[randomNumber];

        ChangeMusicClipAndPlay(gameSceneClip);
    }

    public void ChangeMusicClipAndPlay(AudioClip musicClip)
    {
        musicAudioSource.clip = musicClip;
        musicAudioSource.Play();
    }
}