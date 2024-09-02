using System.Collections;
using System.Collections.Generic;
using Agava.YandexGames;
using UnityEngine;

namespace Source.Scripts.Ui
{
    public class LeaderBoard : MonoBehaviour
    {
        [SerializeField] private GameObject _templatePlayer;
        [SerializeField] private Transform _groupLeaderBoard;
        
        private static string LeaderboardName = "Stars";
        
        private List<GameObject> _list =new List<GameObject>();
        private GameObject _currentPlayer;
        private int _topPlayersCount = 5;
        private int _competingPlayers = 1;

        private void OnEnable()
        {
            StartCoroutine(CheckWorkSdkAndShowLeaderboard());
        }

        private void OnDisable()
        {
            if (_list != null)
            {
                foreach (var player in _list)
                {
                    Destroy(player);
                }
            }
        }

        public void GetLeaderboardEntries()
        {
            Leaderboard.GetEntries(LeaderboardName, (result) =>
            {
                for (int i = 0; i < result.entries.Length; i++)
                {
                    string name = result.entries[i].player.publicName;
                    string rank = result.entries[i].rank.ToString();
                    string score = result.entries[i].score.ToString();

                    if (string.IsNullOrEmpty(name))
                        name = StaticText.Anonymous;

                    _currentPlayer = Instantiate(_templatePlayer,_groupLeaderBoard.transform);
                    _currentPlayer.GetComponent<LeaderBoardPlayer>().SetView(rank, name, score);
                    _list.Add(_currentPlayer);
                }
            }, null, _topPlayersCount, _competingPlayers);
        }
    
        IEnumerator CheckWorkSdkAndShowLeaderboard()
        {
#if !UNITY_WEBGL || UNITY_EDITOR
            yield break;
#endif
            if (!YandexGamesSdk.IsInitialized)
                yield return YandexGamesSdk.Initialize();
            PlayerAccount.RequestPersonalProfileDataPermission(() => GetLeaderboardEntries());
        }
    }
}