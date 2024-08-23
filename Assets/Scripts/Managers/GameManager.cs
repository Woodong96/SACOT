using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TMP_Text currentTime;
    public float CurrentTime;
    public TMP_Text gameScore;
    public int GameScore;
    public GameObject[] Customer;
    public GameObject FirstCustomer;
    public static GameManager Instance { get; private set; }
    // Start is called before the first frame update
    private void Awake()
    {
      
        if (Instance == null)
        {
            Instance = this;
           
            DontDestroyOnLoad(gameObject);
        }
        else
        {
           
            Destroy(gameObject);
        }

        
    }
    void Start()
    {
        LoadFinalScore();
        CurrentTime = 5;
        GameScore = 0;
        Time.timeScale = 1;
       
    }

    // Update is called once per frame
    void Update()
    {
        CurrentTime -= Time.deltaTime;
        currentTime.text = CurrentTime.ToString("F1");
        

        gameScore.text = GameScore.ToString("F0");
        if (FirstCustomer == null)
        {
            FirstCustomer = Customer[0];
        }
        if (CurrentTime <= 0)
        {
            CurrentTime = 0; 
            EndGame();
        }


    }
    void SaveFinalScore(int score)
    {
        
        if (PlayerPrefs.GetInt("FinalScore") == null || PlayerPrefs.GetInt("FinalScore") < score)
        {
            PlayerPrefs.SetInt("FinalScore", score); // "FinalScore"라는 키로 스코어 저장
            PlayerPrefs.Save(); // 데이터를 디스크에 저장
        }



    }
    public void ChangeFirstCustomer()
    {
        Destroy(FirstCustomer);
       
            Customer[0] = Customer[1];
            Customer[1] = Customer[2];
            Customer[2] = Customer[3];



    }

    void LoadFinalScore()
    {
        if (PlayerPrefs.HasKey("FinalScore"))
        {
            GameScore = PlayerPrefs.GetInt("FinalScore");
            Debug.Log("Final Score Loaded: " + GameScore);
        }
        else
        {
            GameScore = 0; // 저장된 스코어가 없을 경우 초기화
        }
    }

    public void EndGame()
    { 
        {
            Time.timeScale = 0;
            SaveFinalScore(GameScore);
            Debug.Log(PlayerPrefs.GetInt("FinalScore"));
            AudioManager.Instance.StopBGM();
            Debug.Log(PlayerPrefs.GetInt("FinalScore"));
            UIManager.Instance.PopUpEnding(true);
            Debug.Log(PlayerPrefs.GetInt("FinalScore"));
        }
    }


}
