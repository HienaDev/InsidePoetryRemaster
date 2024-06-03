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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadMenu() => SceneManager.LoadScene(nameMenuScene);

    public void Restart() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

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
