using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    [Header("Score Labels")]
    public TMP_Text l1HighText;
    public TMP_Text l1TimeText;
    public TMP_Text l2HighText;
    public TMP_Text l2TimeText;

    [Header("Scene Names")]
    public string level1Scene = "Level1";
    public string innovationScene = "InnovationScene";
    // Start is called before the first frame update
    void Start()
    {
        int l1hs = PlayerPrefs.GetInt("L1_HS", 0);
        string l1time = PlayerPrefs.GetString("L1_TIME", "00:00:00");
        int l2hs = PlayerPrefs.GetInt("L2_HS", 0);
        string l2time = PlayerPrefs.GetString("L2_TIME", "00:00:00");

        if (l1HighText) l1HighText.text = $"L1 High: {l1hs:000000}";
        if (l1TimeText) l1TimeText.text = $"L1 Time: {l1time}";
        if (l2HighText) l2HighText.text = $"L2 High: {l2hs:000000}";
        if (l2TimeText) l2TimeText.text = $"L2 Time: {l2time}";
    }
    public void LoadLv1()
    {
        SceneManager.LoadScene("Level1");
    }

    // Level 2 °´Å¥ÊÂ¼þ
    public void LoadLv2()
    {
        SceneManager.LoadScene("InnovationScene");
    }


// Update is called once per frame
void Update()
    {
        
    }
}
