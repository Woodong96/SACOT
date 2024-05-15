using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TMP_Text currentTime;
    private float CurrentTime;
    // Start is called before the first frame update
    void Start()
    {
        CurrentTime = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        CurrentTime += Time.deltaTime;
        currentTime.text = CurrentTime.ToString("F2");
    }
}
