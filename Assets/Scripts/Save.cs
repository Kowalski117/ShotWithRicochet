using UnityEngine;
using UnityEngine.SceneManagement;

public class Save : MonoBehaviour
{
    private string _coins = "Coins";
    private string _IsFirstPassLevel = "IsFirstPassLevel";

    public int Coins()
    {
        return PlayerPrefs.GetInt(_coins);
    }

    public bool IsFirstPassLevel()
    {
        bool value;
        value = PlayerPrefs.GetInt(_IsFirstPassLevel+ TakeIndexLevel().ToString()) == 0;
        return value;
    }

    public bool IsFirstPassLevel(int indexLevel)
    {
        bool value;
        value = PlayerPrefs.GetInt(_IsFirstPassLevel + indexLevel.ToString()) == 0;
        return value;
    }

    public void LevelStats(int coins,bool levelCompleted)
    {
        PlayerPrefs.SetInt(_coins,coins);
        PlayerPrefs.SetInt(_IsFirstPassLevel + TakeIndexLevel(), levelCompleted ? 1:0);
    }

    private int TakeIndexLevel()
    {
        return SceneManager.GetActiveScene().buildIndex;
    }
}
