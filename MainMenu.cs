using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public GameObject SettingsMenu;
    public GameObject LoadMenu;
    public GameObject AboutMenu;
    public Text Version;
    public Slider LoadProgress;
    public void Settings(){
        SettingsMenu.SetActive(true);
    }
    public void NewGame(){
        LoadMenu.SetActive(true);
        StartCoroutine(LoadAsync("Game"));
        
    }
    public void ContinueGame(){
        LoadMenu.SetActive(true);
        StartCoroutine(LoadAsync("Game"));
    }
    public void About(){
        AboutMenu.SetActive(true);
        Version.text="Version : " + Application.version;
    }
    public void AboutExit(){
        AboutMenu.SetActive(false);
    }
    public void ExitSettings(){
        SettingsMenu.SetActive(false);
    }
    IEnumerator LoadAsync(string SceneName)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(SceneName);

        while (!asyncLoad.isDone)
        {
            LoadProgress.value=Mathf.Clamp01(asyncLoad.progress/.9f);
            yield return null;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
