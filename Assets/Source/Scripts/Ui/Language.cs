using System.Collections;
using Agava.YandexGames;
using UnityEngine;

namespace Source.Scripts.Ui
{
    public class Language : MonoBehaviour
    {
        private static string _empty = "";
        private string _current;

        private void Start()
        {
            StartCoroutine(Lang());
        }

        private void Set()
        {
            switch (_current)
            {
                case "en":
                    Lean.Localization.LeanLocalization.SetCurrentLanguageAll(ValueConstants.English);
                    break;

                case "ru":
                    Lean.Localization.LeanLocalization.SetCurrentLanguageAll(ValueConstants.Russian);
                    break;

                case "tr":
                    Lean.Localization.LeanLocalization.SetCurrentLanguageAll(ValueConstants.Turkish);
                    break;
            }
        }

        IEnumerator Lang()
        {
#if !UNITY_WEBGL || UNITY_EDITOR
            yield break;
#endif
            if (!YandexGamesSdk.IsInitialized)
                yield return YandexGamesSdk.Initialize();

            if (Save.GetLanguage() == _empty)
                _current = YandexGamesSdk.Environment.i18n.lang;
            else
                _current = Save.GetLanguage();
            Set();
            Save.SetLanguage(_current);
            StickyAd.Show();
        }
    }
}