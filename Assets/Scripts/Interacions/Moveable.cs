using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moveable : MonoBehaviour, IActionable
{
    public PlayerControls player;
    public bool MoveEnable;

    private void Update()
    {
        if(MoveEnable == true && Input.GetKey(KeyCode.LeftAlt))
        {
            MoveEnable = false;
            transform.parent = null;        }
    }
    public void Interact()
    {
        if (MoveEnable == false)
        {
            print("INTERACTION");
            MoveEnable = true;
            transform.parent = player.transform;
        }
     }

    public bool IsInteractable()
    {
        return !MoveEnable;
    }


}

