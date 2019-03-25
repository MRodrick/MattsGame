using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TentCheckCollider : MonoBehaviour
{
    public GameObject me;
    // Start is called before the first frame update
    void Start()
    {
        print(gameObject.name);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2d(Collider2D other) {
       
            Destroy(me);
        
    }
}
