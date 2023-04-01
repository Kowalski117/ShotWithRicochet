using Agava.YandexGames;
using System.Collections;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]

public class AdCoinButton : MonoBehaviour
{
    private Button _button;
    private Coroutine _coroutine;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(ShowAd);
    }
    private void OnDisable()
    {
        _button.onClick.RemoveListener(ShowAd);
    }

    private void ShowAd()
    {
        if(_coroutine != null )
            StopCoroutine(_coroutine);
        else
            _coroutine = StartCoroutine(ShowShouldInvokeErrorCallback());
    }

    public IEnumerator ShowShouldInvokeErrorCallback()
    {
        Debug.Log("реклама");
        bool callbackInvoked = false;
        VideoAd.Show(onErrorCallback: (message) =>
        {
            callbackInvoked = true;
        });

        yield return new WaitForSecondsRealtime(1);

        Assert.IsTrue(callbackInvoked);
    }
}
