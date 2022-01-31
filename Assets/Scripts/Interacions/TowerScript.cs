using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerScript : MonoBehaviour , IActionable
{
    public PlayerControls Player;
    public Text _baseText;
    public bool _baseInteraction;
    public Collider2D baseCollider;
    public PlayerEvents pc;


     public void Interact()
     {
        Player = FindObjectOfType<PlayerControls>();
       _baseText.text = "That look disgusting, i should better be careful";
        _baseInteraction = true;
        Destroy(_baseText, 5);
     }

    public bool IsInteractable()
    {
        return !_baseInteraction;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Player")
        {
            pc = FindObjectOfType<PlayerEvents>();
            pc.poison_buff.Invoke();
        }
    }
}
