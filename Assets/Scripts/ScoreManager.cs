using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{

    public Text levelText;
    public int scoreCount;
    GameManager gameManagerscripts;
    LevelDesign levelDesignScript;
    // Start is called before the first frame update
    void Start()
    {
        GameObject gameManagerLevel = GameObject.FindGameObjectWithTag("GameManager");
         levelDesignScript = gameManagerLevel.GetComponent<LevelDesign>();

    }

    // Update is called once per frame
    void Update()
    {
        scoreCount++;
        levelText.text = " Level: " + levelDesignScript.numberOfLevels;
    }
}



