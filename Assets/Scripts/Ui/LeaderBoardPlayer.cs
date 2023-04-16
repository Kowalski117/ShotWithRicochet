using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LeaderBoardPlayer : MonoBehaviour
{
    [SerializeField] private TMP_Text _rank;
    [SerializeField] private TMP_Text _name;
    [SerializeField] private TMP_Text _score;

    public void SetView(string rank, string name, string score)
    {
        _rank.text = rank;
        _name.text = name;
        _score.text = score;
    }
}
