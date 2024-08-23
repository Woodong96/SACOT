using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public TMP_Text BestScore;
    public GameObject EndingPopup;
    public static UIManager Instance { get; private set; }
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

    // Update is called once per frame
    private void Start()
    {
        
    }

    // 최종 스코어를 UI에 업데이트하는 함수
    public void UpdateBestScoreUI()
    {
        Debug.Log(PlayerPrefs.GetInt("FinalScore"));
        int finalScore = PlayerPrefs.GetInt("FinalScore");
        BestScore.text = "Best Score: " + finalScore.ToString();
        Debug.Log(PlayerPrefs.GetInt("FinalScore"));
    }

    public void PopUpEnding(bool _OnOff)
    {
        UpdateBestScoreUI();
        EndingPopup.SetActive(_OnOff);

    }
}
