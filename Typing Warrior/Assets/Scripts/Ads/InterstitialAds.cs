using UnityEngine;
using UnityEngine.Advertisements;

public class InterstitialAds : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener
{
    [Header("ADS MAIN PARAMETERS")]
    [SerializeField] private string androidAdUnitId = "Interstitial_Android";
    [SerializeField] private string iOsAdUnitId = "Interstitial_iOS";
    [SerializeField] private int adsShowingProbability = 20;
    private string adUnitId;

    void Awake()
    {
        adUnitId = (Application.platform == RuntimePlatform.IPhonePlayer)
            ? iOsAdUnitId
            : androidAdUnitId;
    }

    private void OnEnable()
    {
        StaticEventHandler.OnLevelCompleted += StaticEventHandler_OnLevelCompleted;
        StaticEventHandler.OnPlayerLost += StaticEventHandler_OnPlayerLost;
    }

    private void OnDisable()
    {
        StaticEventHandler.OnLevelCompleted -= StaticEventHandler_OnLevelCompleted;
        StaticEventHandler.OnPlayerLost -= StaticEventHandler_OnPlayerLost;
    }

    private void StaticEventHandler_OnLevelCompleted()
    {
        if (ProbabilitiesController.CheckProbability(adsShowingProbability))
        {
            ShowAd();
        }
    }

    private void StaticEventHandler_OnPlayerLost()
    {
        if (ProbabilitiesController.CheckProbability(adsShowingProbability))
        {
            ShowAd();
        }
    }

    public void LoadAd()
    {
        Debug.Log("Loading Ad: " + adUnitId);
        Advertisement.Load(adUnitId, this);
    }

    public void ShowAd()
    {
        Debug.Log("Showing Ad: " + adUnitId);
        Advertisement.Show(adUnitId, this);
    }

    public void OnUnityAdsAdLoaded(string adUnitId)
    {

    }

    public void OnUnityAdsFailedToLoad(string _adUnitId, UnityAdsLoadError error, string message)
    {
        Debug.Log($"Error loading Ad Unit: {_adUnitId} - {error.ToString()} - {message}");
    }

    public void OnUnityAdsShowFailure(string _adUnitId, UnityAdsShowError error, string message)
    {
        Debug.Log($"Error showing Ad Unit {_adUnitId}: {error.ToString()} - {message}");
    }

    public void OnUnityAdsShowStart(string _adUnitId) { }
    public void OnUnityAdsShowClick(string _adUnitId) { }
    public void OnUnityAdsShowComplete(string _adUnitId, UnityAdsShowCompletionState showCompletionState) { }
}