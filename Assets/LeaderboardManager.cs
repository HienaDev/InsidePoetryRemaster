using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Dan.Main;
using System.Xml;
using TMPro;


public class LeaderboardManager : MonoBehaviour
{
    [SerializeField] private TMP_Text[] _entryTextObjects;
    [SerializeField] private TMP_InputField _usernameInputField;

    // Make changes to this section according to how you're storing the player's score:
    // ------------------------------------------------------------
    [SerializeField] private Timer timer;

    private int Score => timer.TimeFinal;
    // ------------------------------------------------------------

    private void Start()
    {
        LoadEntries();

        gameObject.SetActive(false);
    }



    private void LoadEntries()
    {
        // Q: How do I reference my own leaderboard?
        // A: Leaderboards.<NameOfTheLeaderboard>

        Leaderboards.AlienJungle.GetEntries(entries =>
        {
            foreach (var t in _entryTextObjects)
                t.text = "";

            var length = Mathf.Min(_entryTextObjects.Length, entries.Length);

            string tempScore;

            for (int i = 0; i < length; i++)
            { 

                tempScore = string.Format("{0:00} : {1:00}", entries[i].Score / 60, (entries[i].Score - ((entries[i].Score / 60) * 60)));

                Debug.Log((entries[i].Score / 60));

                _entryTextObjects[i].text = $"{entries[i].Rank}. {entries[i].Username} - {tempScore}";
            }
        });
    }

    public void UploadEntry()
    {
        Debug.Log(Score);

        LeaderboardCreator.ResetPlayer();

        Leaderboards.AlienJungle.UploadNewEntry(_usernameInputField.text, Score, isSuccessful =>
        {

            if (isSuccessful)
                LoadEntries();
        });
    }
}

