using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ChestBehaviour : MonoBehaviour, IActionable
{
    public Collider2D chestCollider;
    public bool _chestInteraction;
    public Animator _chestAnimation;
    public bool isOpen;
    public GameObject[] arrayGO;
    public Vector2 transformDrop;

    public void Interact()
    {
        transformDrop = new Vector2(this.transform.position.x + Random.Range(-1.5f, 1.5f), this.transform.position.y + Random.Range(0, 1));
        isOpen = true;
        _chestAnimation.SetBool("Interaction", true);
        Instantiate(arrayGO[Random.Range(0, arrayGO.Length)], transformDrop, transform.rotation);
    }

    public bool IsInteractable()
    {
        return !isOpen;
    }
}


