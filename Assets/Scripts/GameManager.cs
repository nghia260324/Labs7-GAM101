using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public TextMeshProUGUI countdownText;
    public GameObject displayEndGame;
    public GameObject displayStartGame;

    public Image iconP;
    public Sprite iconResume;
    public Sprite iconPause;

    public int countdownTime;

    public bool type;

    public bool isPaused = false;


    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        if (type)
        {
            displayStartGame.SetActive(true);
            StartCountdown(countdownTime);
        }
    }
    public void ClickButton()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            PauseGame();
        }
        else
        {
            ResumeGame();
        }

    }
    public void EndGame()
    {
        GameObject newDisplay = Instantiate(displayEndGame);
        PlayerController controller = GameObject.Find("Player").GetComponent<PlayerController>();
        CoinManager manager = controller.GetComponent<CoinManager>();
        GameObject inf = newDisplay.transform.Find("Background").transform.Find("Inf").gameObject;
        inf.transform.Find("Distance").transform.Find("DistanceValue").GetComponent<TextMeshProUGUI>().text = controller.currentDistance.ToString() + "m";
        inf.transform.Find("Coin").transform.Find("CoinValue").GetComponent<TextMeshProUGUI>().text = manager.currentCoint.ToString();
        inf.transform.Find("GameTime").transform.Find("GameTimeValue").GetComponent<TextMeshProUGUI>().text = FormatTime(controller.currentTime);
        inf.transform.Find("Day").transform.Find("DayValue").GetComponent<TextMeshProUGUI>().text = GetCurrentDate();
    }
    private string GetCurrentDate()
    {
        DateTime currentTime = DateTime.Now;

        int day = currentTime.Day;
        int month = currentTime.Month;
        int year = currentTime.Year;

        return string.Format("{0}/{1}/{2}", day, month, year);
    }
    public string FormatTime(float timeInSeconds)
    {
        int hours = (int)(timeInSeconds / 3600);
        int minutes = (int)((timeInSeconds % 3600) / 60);
        int seconds = (int)(timeInSeconds % 60);

        string formattedTime = string.Format("{0:00}:{1:00}:{2:00}", hours, minutes, seconds);
        return formattedTime;
    }

    public void LoadScene(string  sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void StartCountdown(int startValue)
    {
        StartCoroutine(CountdownCoroutine(startValue));
    }

    private IEnumerator CountdownCoroutine(int startValue)
    {
        int count = startValue;

        while (count > 0)
        {
            countdownText.text = count.ToString();
            yield return new WaitForSeconds(1f);
            count--;
        }
        countdownText.text = "0";
        displayStartGame.SetActive(false);
        PlayerManager.instance.CreatePlayer();
    }
    private void PauseGame()
    {
        iconP.sprite = iconResume;
        Time.timeScale = 0f;
    }

    private void ResumeGame()
    {
        iconP.sprite = iconPause;
        Time.timeScale = 1f;
    }
}
