using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{

    [SerializeField] private string nameMenuScene;
    [SerializeField] private AudioMixer audioMixer;


    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private GameObject menuParent;

    // Start is called before the first frame update
    void Start()
    {
        // We do this so leaderboard starts loading
        menuParent.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            menuParent.SetActive(!menuParent.activeSelf);

            if (menuParent.activeSelf) Time.timeScale = 0f;
            else Time.timeScale = 1f;

            playerMovement.enabled = !menuParent.activeSelf;
        }
    }

    public void LoadMenu() => SceneManager.LoadScene(nameMenuScene);

    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


    public void Quit()
    {
#if UNITY_STANDALONE
        // Exit application if running standalone
        Application.Quit();
#endif
#if UNITY_EDITOR
        // Stop game if running in editor
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }

    public void ChangeVolume(Slider volume)
    {
        if(volume.value == 0) audioMixer.SetFloat("Volume", -80f);
        else audioMixer.SetFloat("Volume", Mathf.Lerp(-35, 0, volume.value));

        Debug.Log(volume.value);
    }
}
