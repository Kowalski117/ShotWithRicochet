using System.Collections;
using Agava.YandexGames;
using UnityEngine;

namespace Source.Scripts.Ui
{
    public class Language : MonoBehaviour
    {
        private string _current;
    
        private void Start()
        {
            StartCoroutine(Lang());
        }

        IEnumerator Lang()
        {
#if !UNITY_WEBGL || UNITY_EDITOR
            yield break;
#endif
            if (!YandexGamesSdk.IsInitialized)
                yield return YandexGamesSdk.Initialize();

            if (Save.GetLanguage() == "")
                _current = YandexGamesSdk.Environment.i18n.lang;
            else
                _current = Save.GetLanguage();
            Set();
            Save.SetLanguage(_current);
            StickyAd.Show();
        }

        private void Set()
        {
            switch (_current)
            {
                case "en":
                    Lean.Localization.LeanLocalization.SetCurrentLanguageAll(StaticText.English);
                    break;

                case "ru":
                    Lean.Localization.LeanLocalization.SetCurrentLanguageAll(StaticText.Russian);
                    break;

                case "tr":
                    Lean.Localization.LeanLocalization.SetCurrentLanguageAll(StaticText.Turkish);
                    break;
            }
        }
    }
}