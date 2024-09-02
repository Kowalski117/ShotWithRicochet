using System.Collections;
using Agava.YandexGames;
using Source.Scripts.Ui;
using UnityEngine;

namespace Source.Scripts
{
    public class ShowInterstitialAd : MonoBehaviour
    {
        [SerializeField] private MixerSetting _mixer;
    
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
            InterstitialAd.Show(() => _mixer.Mute(),(bool _) => _mixer.Load(), null);
        }
    }
}