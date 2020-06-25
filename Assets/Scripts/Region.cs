using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using System.IO;



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
    public float Rt;//здоровые в предыдущий день
    public float Dt;//умершие в предыдущий день
    public float dR;//прирост выздоровевших
    public float dD;//прирост умерших
    /*public float dI;
    public int day;

    public List<int> listS = new List<int>();
    public List<int> listR = new List<int>();
    public List<int> listD = new List<int>();
    public List<int> listI = new List<int>();
    public List<int> listdR = new List<int>();
    public List<int> listdD = new List<int>();
    public List<int> listdI = new List<int>();*/
    /*void SaveFile(List<int> list,string f)
{
	StreamWriter sw = new StreamWriter(Application.dataPath + "/" + f + ".txt");
	string sp = " ";

	for(int i = 0; i < list.Count; i++)
	{
		sw.WriteLine(list[i]);
	}
	
	sw.Close();
}*/


    // Start is called before the first frame update
    void Start()
    {
        GameObject Settings = GameObject.Find("Settings");
        Settings SettingsScript=Settings.GetComponent<Settings>();
        N=SettingsScript.N/5f;
        I=SettingsScript.I/5f;
        C=SettingsScript.C;
        g=SettingsScript.g;
        float a=SettingsScript.a;
        D=0f;
        R=0f;

        S=N-I-D-R;
        gamma=1f/g;
        beta=gamma*C;
        alpha=a*gamma/100;
        GameScript = GameControl.GetComponent<GameContoller>();
        Rt=0;
        Dt=0;
        //day=0;
        StartCoroutine("SickPlusPlus");
    }
    IEnumerator SickPlusPlus()
    {
        for (; ; )
        {   
            St=S;
            It=I;
            R=R+gamma*Mathf.Floor(I);
            D=D+alpha*Mathf.Floor(I);
            dR=Mathf.Floor(R)-Mathf.Floor(Rt);
            dD=Mathf.Floor(D)-Mathf.Floor(Dt);
            if(dR>0){
                I=I+beta*Mathf.Floor(I)*Mathf.Floor(S)/N-dR;
                Rt=Mathf.Floor(R);
            }
            if(dD>0){
                I=I+beta*Mathf.Floor(I)*Mathf.Floor(S)/N-dD;
                Dt=Mathf.Floor(D);
            }
            if(dD==0 & dR==0){
                I=I+beta*Mathf.Floor(I)*Mathf.Floor(S)/N;
            }
            S=N-Mathf.Floor(I)-Mathf.Floor(R)-Mathf.Floor(D);
            
            //I=I+beta*I*St/N-(gamma+alpha)*I;
            
           // dI=beta*I*St/N;
            //I=I+beta*I*St/N-(gamma+alpha)*I;
            /*listI.Add(Mathf.FloorToInt(I));
            listD.Add(Mathf.FloorToInt(D));
            listR.Add(Mathf.FloorToInt(R));
            listS.Add(Mathf.FloorToInt(S));
            listdI.Add(Mathf.FloorToInt(dI));
            listdD.Add(Mathf.FloorToInt(dD));
            listdR.Add(Mathf.FloorToInt(dR));
            
            day++;
            if(listI.Count==600){
                SaveFile(listI,"I");
                SaveFile(listR,"R");
                SaveFile(listD,"D");
                SaveFile(listS,"S");
                SaveFile(listdI,"dI");
                SaveFile(listdR,"dR");
                SaveFile(listdD,"dD");
            }*/
            yield return new WaitForSeconds(1f/GameScript.time);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
