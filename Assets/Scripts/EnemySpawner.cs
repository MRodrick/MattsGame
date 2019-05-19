using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject skelly;
    bool spawn = false;
    void Start()
    {
       InvokeRepeating("spawner", 0.0f, 3.0f);
    }

    // Update is called once per frame
    void Update()
    {
        //StartCoroutine("Idle");
        
    }

   /* IEnumerator Idle() {
        yield return new WaitForSeconds(10f);
    }*/
    bool spawner() {
        Instantiate(skelly, new Vector3(transform.position.x, transform.position.y - 0.7f, 0), Quaternion.identity);

        return false;
    }
}
