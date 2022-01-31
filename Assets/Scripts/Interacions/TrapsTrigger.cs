using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapsTrigger : MonoBehaviour
{
    SpriteRenderer sr;
    public GameObject _base;
    public bool isOn;
    public PlayerControls player;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

 /*   private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag != "Damageable" && isOn == false)
        {
            isOn = true;
            sr.color = Color.green;
            _base.SetActive(false);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //HOW TO MAKE COLLIDER EXIT RECOGNIZE WHICH COLLIDER ENTERED?
        if(collision.tag != "Damageable" && isOn == true)
        {
            isOn = false;
            sr.color = Color.red;
            _base.SetActive(true);

        }
    }*/
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag != "Damageable" && collision.collider.tag != "Player" && isOn == false)
        {
            isOn = true;
            sr.color = Color.green;
            _base.SetActive(false);
            FMODUnity.RuntimeManager.PlayOneShot("event:/Player/_triggerOn");
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.collider.tag != "Damageable" && collision.collider.tag != "Player" && isOn == true)
        {
            isOn = false;
            sr.color = Color.red;
            _base.SetActive(true);
        }
    }
}