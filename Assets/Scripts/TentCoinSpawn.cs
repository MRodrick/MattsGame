using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TentCoinSpawn : MonoBehaviour
{
    public GameObject coinSpawn;
    float Timer = 0.0f;
    Vector3 pos;
    Vector3 spawnPos;

    // Start is called before the first frame update
    void Start()
    {
        coinSpawn = GameObject.FindWithTag("Coin");
        InvokeRepeating("spawnCoin", 3f,3f);
        pos = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Timer += Time.deltaTime;
        if (Timer - 4 == 0) {
            Timer = 0;

            Instantiate(coinSpawn, spawnPos, Quaternion.identity);
        }
    }
    void spawnCoin() {
        spawnPos = new Vector3(pos.x, pos.y, pos.z-0.1f);
        Instantiate(coinSpawn, spawnPos, Quaternion.identity);
    }

}
