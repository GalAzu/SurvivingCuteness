using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public Transform _mine, _spike, _mace;
    public GameObject[] collectibles;
    // Start is called before the first frame update
    void Start()
    {

        InvokeRepeating("MineSpawn", Random.Range(1, 7), 2);
        InvokeRepeating("MaceSpawn", Random.Range(2, 4), Random.Range(1, 3));
        InvokeRepeating("SpikeSpawn", Random.Range(2, 3), Random.Range(1, 6));
        InvokeRepeating("collectiblesSpawn", Random.Range(1, 10), Random.Range(2, 10));
    }
    private void Update()
    {
        Amulet amulet = FindObjectOfType<Amulet>();
    }

    public void MineSpawn()
    {
        Transform newMine = Instantiate(_mine, GetRandomPos(), transform.rotation);
        Destroy(newMine.gameObject, 3);
    }
    public void SpikeSpawn()
    {
        Transform newSpike = Instantiate(_spike, GetRandomPos(), transform.rotation);
        Destroy(newSpike.gameObject, 3);
    }
    public void MaceSpawn()
    {
        Transform newMace = Instantiate(_mace, GetRandomPos(), transform.rotation);
        Destroy(newMace.gameObject, 3);
    }
    private Vector3 GetRandomPos()
    {
        return new Vector3(Random.Range(-14, 40), Random.Range(2, 4), 0);
    }
    public void collectiblesSpawn()
    {
        GameObject newCollectible = Instantiate(collectibles[Random.Range(0, collectibles.Length)], GetRandomPos(), transform.rotation);
        Destroy(newCollectible, 9);
    }
}
