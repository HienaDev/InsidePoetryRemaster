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


    [SerializeField] private bool deactivateOnStart;

    // Make changes to this section according to how you're storing the player's score:
    // ------------------------------------------------------------
    [SerializeField] private Timer timer;

    private int Score => timer.TimeFinal;
    // ------------------------------------------------------------

    [SerializeField] private bool menu = false;

    [SerializeField] private float distance;

    private void Start()
    {


        transform.position += new Vector3(distance, 0f, 0f);

        LoadEntries();

        gameObject.SetActive(!deactivateOnStart);
    }



    private void LoadEntries()
    {
        // Q: How do I reference my own leaderboard?
        // A: Leaderboards.<NameOfTheLeaderboard>

        Debug.Log("entries loadead");

        foreach (var t in _entryTextObjects)
            t.text = "Loading...";

        Leaderboards.AlienJungle.GetEntries(entries =>
        {
            

            var length = Mathf.Min(_entryTextObjects.Length, entries.Length);

            Debug.Log(entries.Length);

            string tempScore;

            for (int i = 0; i < _entryTextObjects.Length; i++)
            {

                if (i >= entries.Length)
                    _entryTextObjects[i].text= " ";
                else
                {
                    tempScore = string.Format("{0:00} : {1:00}", entries[i].Score / 60, (entries[i].Score - ((entries[i].Score / 60) * 60)));

                    Debug.Log((entries[i].Score / 60));

                    _entryTextObjects[i].text = $"{entries[i].Rank}. {entries[i].Username} - {tempScore}";
                }
                
            }
        });

       
        if (!menu)
        {
            transform.position -= new Vector3(distance, 0f, 0f);
            gameObject.SetActive(false);
            menu = true;
        }
            


    }

    public void UploadEntry()
    {
        Debug.Log(Score);

        foreach (var t in _entryTextObjects)
            t.text = "Loading...";

        LeaderboardCreator.ResetPlayer();

        Leaderboards.AlienJungle.UploadNewEntry(_usernameInputField.text, Score, isSuccessful =>
        {

            if (isSuccessful)
                LoadEntries();
        });
    }
}

