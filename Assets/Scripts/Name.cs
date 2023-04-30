using System.Collections;
using Agava.YandexGames;
using Lean.Localization;
using TMPro;
using UnityEngine;

public class Name : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    
    private void Start()
    {
        StartCoroutine(CheckWorkSDK());
    }

    IEnumerator CheckWorkSDK()
    {
#if !UNITY_WEBGL || UNITY_EDITOR
        yield break;
#endif
        if (!YandexGamesSdk.IsInitialized)
            yield return YandexGamesSdk.Initialize();
        ViewName();
    }

    private void ViewName()
    {
        PlayerAccount.GetProfileData((result) =>
        {
            string name = result.publicName;
            if (string.IsNullOrEmpty(name))
                name = "Anonymous";
            _text.text = name;
            _text.GetComponent<LeanLocalizedTextMeshProUGUI>().enabled = false;
        });
    }

}
