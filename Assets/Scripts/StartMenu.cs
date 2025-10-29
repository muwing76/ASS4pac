using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public TMP_Text HScore;
    public TMP_Text time;
    // Start is called before the first frame update
    void Start()
    {
        //读取上次分数和时间
        int lastScore = PlayerPrefs.GetInt("HighScore", 0);
        float lastTime = PlayerPrefs.GetFloat("LastTime", 0f);

        HScore.text = "Last High Score: " + lastScore.ToString();
        time.text = "Last Time: " + lastTime.ToString("0.0") + "s";
    }
    public void LoadLevel1()
    {
        SceneManager.LoadScene("Level1");
    }

    // Level 2 按钮事件
    public void LoadLevel2()
    {
        SceneManager.LoadScene("InnovationScene");
    }


// Update is called once per frame
void Update()
    {
        
    }
}
