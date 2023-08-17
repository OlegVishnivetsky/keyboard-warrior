using UnityEngine;

public class AudioController : SingletonMonobehaviour<AudioController>
{
    [Header("AUDIO SOURCE COMPONENTS")]
    [SerializeField] private AudioSource musicAudioSource;
    [SerializeField] private AudioSource soundEffectsAudioSource;

    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(gameObject);
    }

    private void OnEnable()
    {
        SceneController.OnSceneChanged += SceneController_OnSceneChanged;
    }

    private void OnDisable()
    {
        SceneController.OnSceneChanged -= SceneController_OnSceneChanged;
    }

    private void SceneController_OnSceneChanged(string sceneName)
    {
        ChangeMusicDependingOnTheCurrentScene(sceneName);
    }

    private void ChangeMusicDependingOnTheCurrentScene(string sceneName)
    {
        switch (sceneName)
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

    public float GetMusicAudioSourceVolume()
    {
        return musicAudioSource.volume;
    }

    public void SetMusicAudioSourceVolume(float value)
    {
        musicAudioSource.volume = value;
    }

    public float GetSoundEffectsAudioSourceVolume()
    {
        return soundEffectsAudioSource.volume;
    }

    public void SetSoundEffectsAudioSourceVolume(float value)
    {
        soundEffectsAudioSource.volume = value;
    }

    public void PlaySoundEffect(SoundEffectSO soundEffect)
    {
        float randomPitch = Random.Range(soundEffect.soundEffectPitchRandomVariationMin,
            soundEffect.soindEffectPitchRandomVariationMax);

        soundEffectsAudioSource.pitch = randomPitch;
        soundEffectsAudioSource.PlayOneShot(soundEffect.soundEffectClip);
    }

    public void PlayRandomBattleMusic()
    {
        int randomNumber = Random.Range(0, GameResources.Instance.gameSceneMusicList.Count);
        AudioClip gameSceneClip = GameResources.Instance.gameSceneMusicList[randomNumber];

        ChangeMusicClipAndPlay(gameSceneClip);
    }

    public void ChangeMusicClipAndPlay(AudioClip musicClip)
    {
        if (musicAudioSource.clip == GameResources.Instance.mainMenuMusic
            && musicClip == GameResources.Instance.mainMenuMusic)
        {
            return;
        }

        musicAudioSource.clip = musicClip;
        musicAudioSource.Play();
    }
}