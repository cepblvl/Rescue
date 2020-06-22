using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Region : MonoBehaviour
{
    public GameObject GameControl;
    private GameContoller GameScript;

    //Характеристики
    public int Population;
    public int Sick=0;
    public int Dead;
    public int Health;
    public int g;  //дни, за которые происходит излечение от болезни
    public float gamma; //величина, обратная среднему инкубационному периоду заболевания
    public float beta; //контролирующий уровень передачи заболевания при воздействии
    public float alpha; //уровень смертности




    // Start is called before the first frame update
    void Start()
    {
        GameScript = GameControl.GetComponent<GameContoller>();
        StartCoroutine("SickPlusPlus");
    }
    IEnumerator SickPlusPlus()
    {
        for (; ; )
        {
            Sick++;
            yield return new WaitForSeconds(1f/GameScript.time);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
