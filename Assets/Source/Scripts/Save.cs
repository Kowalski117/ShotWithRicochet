using Agava.YandexGames;
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

        public static int GetCoins()
        {
            return PlayerPrefs.GetInt(ValueConstants.Coins);
        }

        public static void SetCoins(int coins)
        {
            PlayerPrefs.SetInt(ValueConstants.Coins, coins);
        }

        public static int GetAllStars()
        {
            return PlayerPrefs.GetInt(ValueConstants.AllStars);
        }

        public static void SetAllStars(int stars)
        {
            PlayerPrefs.SetInt(ValueConstants.AllStars, stars);

#if UNITY_WEBGL && !UNITY_EDITOR
        Leaderboard.GetPlayerEntry(StaticText.LeaderBoard, (result) =>
        {
            if (result != null)
            {
                if (result.score < GetAllStars())
                {
                    Leaderboard.SetScore(StaticText.LeaderBoard,GetAllStars());
                }
            }
        });
#endif
        }

        public static int GetStarsLevel(int indexLevel)
        {
            return PlayerPrefs.GetInt(ValueConstants.Stars + indexLevel);
        }

        public static bool IsLevelPassed()
        {
            bool value;
            value = PlayerPrefs.GetInt(ValueConstants.IsFirstPassLevel + TakeIndexLevel().ToString()) != 0;
            return value;
        }

        public static bool IsLevelPassed(int indexLevel)
        {
            bool value;
            value = PlayerPrefs.GetInt(ValueConstants.IsFirstPassLevel + indexLevel.ToString()) != 0;
            return value;
        }

        public static void LevelStats(int coins, bool levelCompleted, int stars)
        {
            SetCoins(coins);
            PlayerPrefs.SetInt(ValueConstants.IsFirstPassLevel + TakeIndexLevel(), levelCompleted ? 1 : 0);

            if (GetStarsLevel(TakeIndexLevel()) < stars)
            {
                int value;
                value = stars - GetStarsLevel(TakeIndexLevel());
                SetAllStars(GetAllStars() + value);
                PlayerPrefs.SetInt(ValueConstants.Stars + TakeIndexLevel(), stars);
            }
        }

        public static int TakeIndexLevel()
        {
            return SceneManager.GetActiveScene().buildIndex;
        }

        public static void SetLanguage(string language)
        {
            PlayerPrefs.SetString(ValueConstants.Language, language);
        }

        public static string GetLanguage()
        {
            return PlayerPrefs.GetString(ValueConstants.Language);
        }

        public static void SetCharacter(int value)
        {
            PlayerPrefs.SetInt(ValueConstants.Character, value);
        }

        public static int GetCharacter()
        {
            return PlayerPrefs.GetInt(ValueConstants.Character);
        }

        public static void SetCharacterBuyed(int index, bool isBuyed)
        {
            PlayerPrefs.SetInt(ValueConstants.Character + index, isBuyed ? 1 : 0);
        }

        public static bool GetCharacterBuyed(int index)
        {
            bool value;
            value = PlayerPrefs.GetInt(ValueConstants.Character + index) != 0;
            return value;
        }

        public static void SetWeapon(int value)
        {
            PlayerPrefs.SetInt(ValueConstants.Weapon, value);
        }

        public static int GetWeapon()
        {
            return PlayerPrefs.GetInt(ValueConstants.Weapon);
        }

        public static void SetWeaponBuyed(int index, bool isBuyed)
        {
            PlayerPrefs.SetInt(ValueConstants.Weapon + index, isBuyed ? 1 : 0);
        }

        public static bool GetWeaponBuyed(int index)
        {
            bool value;
            value = PlayerPrefs.GetInt(ValueConstants.Weapon + index) != 0;
            return value;
        }

        public static void SetBulletParticle(int value)
        {
            PlayerPrefs.SetInt(ValueConstants.Bullet, value);
        }

        public static int GetBulletParticle()
        {
            return PlayerPrefs.GetInt(ValueConstants.Bullet);
        }

        public static void SetBulletParticleBuyed(int index, bool isBuyed)
        {
            PlayerPrefs.SetInt(ValueConstants.Bullet + index, isBuyed ? 1 : 0);
        }

        public static bool GetBulletParticleBuyed(int index)
        {
            bool value;
            value = PlayerPrefs.GetInt(ValueConstants.Bullet + index) != 0;
            return value;
        }

        public static void SetMusicIsOn(bool isOnMusic)
        {
            PlayerPrefs.SetInt(ValueConstants.MusicVolume, isOnMusic ? 0 : 1);
        }

        public static bool GetMusicIsOn()
        {
            bool value;
            value = PlayerPrefs.GetInt(ValueConstants.MusicVolume) == 0;
            return value;
        }

        public static void SetSoundIsOn(bool isOnSound)
        {
            PlayerPrefs.SetInt(ValueConstants.SoundVolume, isOnSound ? 0 : 1);
        }

        public static bool GetSoundIsOn()
        {
            bool value;
            value = PlayerPrefs.GetInt(ValueConstants.SoundVolume) == 0;
            return value;
        }

        public static void SetDayUsedGift(int day)
        {
            PlayerPrefs.SetInt(ValueConstants.Day, day);
        }

        public static int GetDayUsedGift()
        {
            return PlayerPrefs.GetInt(ValueConstants.Day);
        }

        public static void SetLeftToGetGift(int leftToGet)
        {
            PlayerPrefs.SetInt(ValueConstants.LeftToGet, leftToGet);
        }

        public static int GetLeftToGetGift()
        {
            return PlayerPrefs.GetInt(ValueConstants.LeftToGet);
        }
    }
}