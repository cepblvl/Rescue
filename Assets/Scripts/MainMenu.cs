using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MainMenu : MonoBehaviour
{

    public GameObject SettingsMenu;
    public GameObject DifficultMenu;
    public GameObject LoadMenu;
    public GameObject AboutMenu;
    public Text Version;
    public Slider LoadProgress;
    public GameObject SettingsObject;
    private Settings SettingsScript;

    // Start is called before the first frame update
    void Start()
    {
        GameObject Settings = GameObject.Find("Settings");
        SettingsScript=Settings.GetComponent<Settings>();
        //SettingsScript=SettingsObject.GetComponent<Settings>();
    }
   
    public void Settings(){
        SettingsMenu.SetActive(true);
    }

    public void NewGame(){
        DifficultMenu.SetActive(true);  
    }

    public void ChooseDifficulteEasy(){

        SettingsScript.N=10000000f;
        SettingsScript.I=5f;
        SettingsScript.C=2f;
        SettingsScript.g=6f;
        SettingsScript.a=1f;
        SettingsScript.Budget=1000000;
        SettingsScript.Unrest=10;

        LoadMenu.SetActive(true);
        StartCoroutine(LoadAsync("Game"));
        
    }
    public void ChooseDifficulteMedium(){
        SettingsScript.N=20000000f;
        SettingsScript.I=50f;
        SettingsScript.C=3f;
        SettingsScript.g=10f;
        SettingsScript.a=2f;
        SettingsScript.Budget=100000;
        SettingsScript.Unrest=50;
        LoadMenu.SetActive(true);
        StartCoroutine(LoadAsync("Game"));
        
    }
    public void ChooseDifficulteHard(){
        SettingsScript.N=40000000f;
        SettingsScript.I=100f;
        SettingsScript.C=4f;
        SettingsScript.g=14f;
        SettingsScript.a=3f;
        SettingsScript.Budget=10000;
        SettingsScript.Unrest=100;
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
