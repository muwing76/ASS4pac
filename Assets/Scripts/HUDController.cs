using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class HUDController : MonoBehaviour
{
    public TMP_Text sText, tText, sTText, lvNameText;
    public GameObject[] lifeIcons; 
    public GameObject blockOverlay; 
    public TMP_Text bigCountdown;
    public void SetScore(int s)
    { 
        sText.text = s.ToString("000000");
    }
    public void SetTimer(float t)
    { 
        int m = (int)(t / 60), 
            s = (int)(t % 60), 
            c = (int)((t - Mathf.Floor(t)) * 100); 
        tText.text = $"{m:00}:{s:00}:{c:00}"; 
    }
    public void SetScared(int sec) 
    { 
        sTText.gameObject.SetActive(sec > 0); 
        if (sec > 0) sTText.text = sec.ToString();
    }
    public void SetLives(int n)
    {
        for (int i = 0; i < lifeIcons.Length; i++) 
            lifeIcons[i].SetActive(i < n); 
    }
    public void ShowBlock(string txt) 
    { 
        blockOverlay.SetActive(true); 
        bigCountdown.text = txt;
        bigCountdown.gameObject.SetActive(true); 
    }
    public void HideBlock() 
    {
        blockOverlay.SetActive(false);
        bigCountdown.gameObject.SetActive(false);
    }
    public void Exit()
    {
        SceneManager.LoadScene("StartScene"); 
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
