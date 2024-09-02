using UnityEngine;
using UnityEngine.SceneManagement;

namespace Source.Scripts
{
    public class Save : MonoBehaviour
    {


        private void Awake()
        {
            SetCharacterBuyed(0, true);
            SetWeaponBuyed(0, true);
            SetBulletParticleBuyed(0, true);
        }

        static public int GetCoins()
        {
            return PlayerPrefs.GetInt(StaticText.Coins);
        }

        static public void SetCoins(int coins)
        {
            PlayerPrefs.SetInt(StaticText.Coins, coins);
        }

        static public int GetAllStars()
        {
            return PlayerPrefs.GetInt(StaticText.AllStars);
        }

        static public void SetAllStars(int stars)
        {
            PlayerPrefs.SetInt(StaticText.AllStars, stars);
            int accountScore;
        
#if UNITY_WEBGL && !UNITY_EDITOR
        Leaderboard.GetPlayerEntry(_leaderBoard, (result) =>
        {
            if (result != null)
            {
                if (result.score < GetAllStars())
                {
                    Leaderboard.SetScore(_leaderBoard,GetAllStars());
                }
            }
        });
#endif
        }

        static public int GetStarsLevel(int indexLevel)
        {
            return PlayerPrefs.GetInt(StaticText.Stars + indexLevel);
        }

        static public bool IsLevelPassed()
        {
            bool value;
            value = PlayerPrefs.GetInt(StaticText.IsFirstPassLevel + TakeIndexLevel().ToString()) != 0;
            return value;
        }

        static public bool IsLevelPassed(int indexLevel)
        {
            bool value;
            value = PlayerPrefs.GetInt(StaticText.IsFirstPassLevel + indexLevel.ToString()) != 0;
            return value;
        }

        static public void LevelStats(int coins, bool levelCompleted, int stars)
        {
            SetCoins(coins);
            PlayerPrefs.SetInt(StaticText.IsFirstPassLevel + TakeIndexLevel(), levelCompleted ? 1 : 0);

            if (GetStarsLevel(TakeIndexLevel()) < stars)
            {
                int value;
                value = stars - GetStarsLevel(TakeIndexLevel());
                SetAllStars(GetAllStars() + value);
                PlayerPrefs.SetInt(StaticText.Stars + TakeIndexLevel(), stars);
            }
        }

        static public int TakeIndexLevel()
        {
            return SceneManager.GetActiveScene().buildIndex;
        }

        static public void SetLanguage(string language)
        {
            PlayerPrefs.SetString(StaticText.Language, language);
        }

        static public string GetLanguage()
        {
            return PlayerPrefs.GetString(StaticText.Language);
        }

        static public void SetCharacter(int value)
        {
            PlayerPrefs.SetInt(StaticText.Character, value);
        }

        static public int GetCharacter()
        {
            return PlayerPrefs.GetInt(StaticText.Character);
        }


        static public void SetCharacterBuyed(int index, bool isBuyed)
        {
            PlayerPrefs.SetInt(StaticText.Character + index, isBuyed ? 1 : 0);
        }

        static public bool GetCharacterBuyed(int index)
        {
            bool value;
            value = PlayerPrefs.GetInt(StaticText.Character + index) != 0;
            return value;
        }

        static public void SetWeapon(int value)
        {
            PlayerPrefs.SetInt(StaticText.Weapon, value);
        }

        static public int GetWeapon()
        {
            return PlayerPrefs.GetInt(StaticText.Weapon);
        }

        static public void SetWeaponBuyed(int index, bool isBuyed)
        {
            PlayerPrefs.SetInt(StaticText.Weapon + index, isBuyed ? 1 : 0);
        }

        static public bool GetWeaponBuyed(int index)
        {
            bool value;
            value = PlayerPrefs.GetInt(StaticText.Weapon + index) != 0;
            return value;
        }

        static public void SetBulletParticle(int value)
        {
            PlayerPrefs.SetInt(StaticText.Bullet, value);
        }

        static public int GetBulletParticle()
        {
            return PlayerPrefs.GetInt(StaticText.Bullet);
        }

        static public void SetBulletParticleBuyed(int index, bool isBuyed)
        {
            PlayerPrefs.SetInt(StaticText.Bullet + index, isBuyed ? 1 : 0);
        }

        static public bool GetBulletParticleBuyed(int index)
        {
            bool value;
            value = PlayerPrefs.GetInt(StaticText.Bullet + index) != 0;
            return value;
        }
    
        static public void SetMusicIsOn(bool isOnMusic)
        {
            PlayerPrefs.SetInt(StaticText.MusicVolume, isOnMusic ? 0 : 1);
        }

        static public bool GetMusicIsOn()
        {
            bool value;
            value = PlayerPrefs.GetInt(StaticText.MusicVolume) == 0;
            return value;
        } 
    
        static public void SetSoundIsOn(bool isOnSound)
        {
            PlayerPrefs.SetInt(StaticText.SoundVolume, isOnSound ? 0 : 1);
        }

        static public bool GetSoundIsOn()
        {
            bool value;
            value = PlayerPrefs.GetInt(StaticText.SoundVolume) == 0;
            return value;
        }

        static public void SetDayUsedGift(int day)
        {
            PlayerPrefs.SetInt(StaticText.Day, day);
        }

        static public int GetDayUsedGift()
        {
            return PlayerPrefs.GetInt(StaticText.Day);
        } 
    
        static public void SetLeftToGetGift(int leftToGet)
        {
            PlayerPrefs.SetInt(StaticText.LeftToGet, leftToGet);
        }

        static public int GetLeftToGetGift()
        {
            return PlayerPrefs.GetInt(StaticText.LeftToGet);
        }
    }
}