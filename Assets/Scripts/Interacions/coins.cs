using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coins : MonoBehaviour
{
    private PlayerEvents pc;
    private void Update()
    {
        transform.Translate(Vector3.down * 2 * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            pc = FindObjectOfType<PlayerEvents>();
            pc.score.Invoke();
            Destroy(this.gameObject);
        }
    }
}
