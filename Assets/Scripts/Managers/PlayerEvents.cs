using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
public class PlayerEvents : MonoBehaviour
{
    private PlayerControls player;
    public Animator playerAnimator;
    private FMOD.Studio.EventInstance slowBuffSound;
    public PlayerControls pc;
    public Animator coinsAnimation;
    public UnityEvent score, poison_buff , Amulet;
    private FMOD.Studio.EventInstance coinSound;
    public int amulet = 0;
    private UImanager UImanager;
    // Start is called before the first frame update
    void Start()
    {
        UImanager = FindObjectOfType<UImanager>();
        player = GameObject.FindObjectOfType<PlayerControls>();
        UImanager.WinCanvas.SetActive(false);    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       /* switch (collision.tag)
        {
            case "coins":
                coins += 1;
                pc.health += 15;
                break;

            case "Poison":
                onPoison();
                Invoke("PoisonOff", 7);
                break;
        }*/

    }

    public void onPoison()
    {
        if(player._poisoned == false)
        {
            slowBuffSound = FMODUnity.RuntimeManager.CreateInstance("event:/Player/_slowBuff");
            player.speed = 3;
            playerAnimator.SetTrigger("Slow");
            print("STATUS EFFECT ON PLAYER");
            player._poisoned = true;
            slowBuffSound.start();
            Invoke("PoisonOff", 5);
        }
    }
    public void PoisonOff()
    {
        player.speed = 5;
        playerAnimator.SetTrigger("Slow");
        print("PLAYER NO LONGER SLOW");
        player._poisoned = false;
        slowBuffSound.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        slowBuffSound.release();
    }
    public void OnCoin()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/Player/_coin");
        player.coins += 1;
        player._health += 10;
    }
    public void OnAmulet()
    {
        amulet += 1;
        if(amulet >= 3)
        {
            Win();
        }
    }
    public void Win()
    {
        Time.timeScale = 0;
        UImanager.WinCanvas.SetActive(true);
        player.bgm.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        player.bgm.release();

    }
}
