using System;
using System.Collections;
using Agava.YandexGames;
using UnityEngine;
using UnityEngine.UI;

public class ShowInterstitialAd : MonoBehaviour
{
    private void Awake()
    {
        YandexGamesSdk.CallbackLogging = true;
    }
    
    private IEnumerator Start()
    {
#if !UNITY_WEBGL || UNITY_EDITOR
        yield break;
#endif
        
        yield return YandexGamesSdk.Initialize();
        InterstitialAd.Show();
    }
}
