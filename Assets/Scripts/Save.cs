using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Save : MonoBehaviour
{
    private static string _coins = "Coins";
    private static string _IsFirstPassLevel = "IsFirstPassLevel";
    private static string _language = "Language";
    private static string _character = "Character";
    private static string _weapon = "Weapons";
    private static string _bullet = "Bullet";
    private static string _stars = "Stars";

    private void Awake()
    {
        SetCharacterBuyed(0, true);
        SetWeaponBuyed(0, true);
        SetBulletParticleBuyed(0, true);
    }

    static public int GetCoins()
    {
        return PlayerPrefs.GetInt(_coins);
    }

    static public void SetCoins(int coins)
    {
        PlayerPrefs.SetInt(_coins, coins);
    }

    static public int GetStars(int stars)
    {
        return PlayerPrefs.GetInt(_stars+stars);
    }

    static public bool IsLevelPassed()
    {
        bool value;
        value = PlayerPrefs.GetInt(_IsFirstPassLevel + TakeIndexLevel().ToString()) != 0;
        return value;
    }

    static public bool IsLevelPassed(int indexLevel)
    {
        bool value;
        value = PlayerPrefs.GetInt(_IsFirstPassLevel + indexLevel.ToString()) != 0;
        return value;
    }

    static public void LevelStats(int coins, bool levelCompleted, int stars)
    {
        SetCoins(coins);
        PlayerPrefs.SetInt(_IsFirstPassLevel + TakeIndexLevel(), levelCompleted ? 1 : 0);

        if (GetStars(TakeIndexLevel()) < stars)
        {
            PlayerPrefs.SetInt(_stars + TakeIndexLevel(),stars);
        }
    }

    static public int TakeIndexLevel()
    {
        return SceneManager.GetActiveScene().buildIndex;
    }

    static public void SetLanguage(string language)
    {
        PlayerPrefs.SetString(_language, language);
    }

    static public string GetLanguage()
    {
        return PlayerPrefs.GetString(_language);
    }

    static public void SetCharacter(int value)
    {
        PlayerPrefs.SetInt(_character, value);
    }

    static public int GetCharacter()
    {
        return PlayerPrefs.GetInt(_character);
    }


    static public void SetCharacterBuyed(int index, bool isBuyed)
    {
        PlayerPrefs.SetInt(_character + index, isBuyed ? 1 : 0);
    }

    static public bool GetCharacterBuyed(int index)
    {
        bool value;
        value = PlayerPrefs.GetInt(_character + index) != 0;
        return value;
    }

    static public void SetWeapon(int value)
    {
        PlayerPrefs.SetInt(_weapon, value);
    }

    static public int GetWeapon()
    {
        return PlayerPrefs.GetInt(_weapon);
    }

    static public void SetWeaponBuyed(int index, bool isBuyed)
    {
        PlayerPrefs.SetInt(_weapon + index, isBuyed ? 1 : 0);
    }

    static public bool GetWeaponBuyed(int index)
    {
        bool value;
        value = PlayerPrefs.GetInt(_weapon + index) != 0;
        return value;
    }

    static public void SetBulletParticle(int value)
    {
        PlayerPrefs.SetInt(_bullet, value);
    }

    static public int GetBulletParticle()
    {
        return PlayerPrefs.GetInt(_bullet);
    }

    static public void SetBulletParticleBuyed(int index, bool isBuyed)
    {
        PlayerPrefs.SetInt(_weapon + index, isBuyed ? 1 : 0);
    }

    static public bool GetBulletParticleBuyed(int index)
    {
        bool value;
        value = PlayerPrefs.GetInt(_weapon + index) != 0;
        return value;
    }
}
