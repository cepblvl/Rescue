using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Region : MonoBehaviour
{
    public GameObject GameControl;
    private GameContoller GameScript;

    //Характеристики
    public float N=10000;//Population
    public float I=1;//Sick
    public float D=0;//Dead
    public float R=0; //Recovering
    public float C=5;//Infect
    public float S;//Health
    public float g=100;  //дни, за которые происходит излечение от болезни
    public float gamma; //величина, обратная среднему инкубационному периоду заболевания
    public float beta; //контролирующий уровень передачи заболевания при воздействии
    public float alpha; //уровень смертности
    public float St;//здоровые в предыдущий день
    public float It;//больные в предыдущий день
    
          



    // Start is called before the first frame update
    void Start()
    {
        S=N-I-D-R;
        gamma=1f/g;
        beta=gamma*C;
        alpha=3*gamma/100;
        GameScript = GameControl.GetComponent<GameContoller>();
        StartCoroutine("SickPlusPlus");
    }
    IEnumerator SickPlusPlus()
    {
        for (; ; )
        {   
            St=S;
            It=I;
            S=S+(-(beta*It*St)/N);
            I=I+beta*It*St/N-(gamma+alpha)*It;
            R=R+gamma*It;
            D=D+alpha*It;
            yield return new WaitForSeconds(1f/GameScript.time);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
