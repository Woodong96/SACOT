using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TMP_Text currentTime;
    private float CurrentTime;
    public TMP_Text gameScore;
    public float GameScore;
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
        CurrentTime = 0;
        GameScore = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        CurrentTime += Time.deltaTime;
        currentTime.text = CurrentTime.ToString("F2");

        gameScore.text = GameScore.ToString("F2");
    }
}
