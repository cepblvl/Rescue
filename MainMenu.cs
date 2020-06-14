using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public GameObject SettingsMenu;
    public void Settings(){
        SettingsMenu.SetActive(true);
    }
    public void ExitSettings(){
        SettingsMenu.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
