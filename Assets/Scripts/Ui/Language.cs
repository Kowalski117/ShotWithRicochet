using Agava.YandexGames;
using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Language : MonoBehaviour
{

    private static string _current;

    private void Start()
    {
        StartCoroutine(Lang());
    }

    IEnumerator Lang()
    {
        if (!YandexGamesSdk.IsInitialized)
            yield return YandexGamesSdk.Initialize();

        if (Save.GetLanguage() == "")
            _current = YandexGamesSdk.Environment.i18n.lang;
        else
            _current = Save.GetLanguage();
        Set();
        Save.SetLanguage(_current);
    }

    private void Set()
    {
        switch (_current)
        {
            case "en":
                Lean.Localization.LeanLocalization.SetCurrentLanguageAll("English");
                break;

            case "ru":
                Lean.Localization.LeanLocalization.SetCurrentLanguageAll("Russian");
                break;

            case "tr":
                Lean.Localization.LeanLocalization.SetCurrentLanguageAll("Turkish");
                break;
        }
    }
}
