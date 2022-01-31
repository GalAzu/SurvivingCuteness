using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UImanager : MonoBehaviour
{
    public int time = 150;
    public float newTime;
    public int newTimeint;
    public int Timer;
    public Text _healthText, _interactionEnable, _OnPowerUp, _CoinsText, _timeText,AmuletText;
    public PlayerControls player;
    public GameObject LoseCanvas, DeathText, TimeOutText, WinCanvas;
    private PlayerEvents playerEvents;

    void Awake()
    {
        Timer = time - newTimeint;
        player = FindObjectOfType<PlayerControls>();
        _healthText.text = ":" + player._health.ToString();
        _timeText.text = "Time: ";
        playerEvents = FindObjectOfType<PlayerEvents>();
    }
    private void Update()
    {
        _CoinsText.text = ":" + player.coins.ToString();
        _timeText.text = "Time: " + Timer.ToString();
        newTime = Time.timeSinceLevelLoad;
        newTimeint = (int)newTime;
        Timer = time - newTimeint;
        AmuletText.text = ":" + playerEvents.amulet.ToString();

    }
    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
}