using Agava.WebUtility;
using UnityEngine;

public class GameActive : MonoBehaviour
{
    private bool _isPaused;

    private void OnEnable()
    {
        WebApplication.InBackgroundChangeEvent += OnInBackgroundChange;
    }

    private void OnDisable()
    {
        WebApplication.InBackgroundChangeEvent -= OnInBackgroundChange;
    }

    private void OnInBackgroundChange(bool inBackground)
    {
        _isPaused = inBackground;
        Change();
    }

    private void OnApplicationFocus(bool hasFocus)
    {
        _isPaused = !hasFocus;
        Change();
    }

    private void Change()
    {
        Time.timeScale = _isPaused ? 0f : 1f;
        AudioListener.pause = _isPaused;
    }
}
