using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine_enemy : MonoBehaviour, IDamagable
{

    public int _damage = 30;
    public int Damage()
    {
        return _damage;
    }

    public void OnDamage()
    {
        var anim = gameObject.GetComponent<Animator>();
        anim.SetTrigger("Hit");
        FMODUnity.RuntimeManager.PlayOneShot("event:/Player/_explosion");
        Debug.Log("ON DAMAGEEEEE");

    }
    public void _Destroy()
    {
        Destroy(gameObject);

    }

}
