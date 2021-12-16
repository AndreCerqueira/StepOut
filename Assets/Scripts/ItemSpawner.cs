using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    [SerializeField] GameObject banana;
    int itemTotal = 10;

    // Start is called before the first frame update
    void Start()
    {

        for (int i = 0; i < itemTotal; i++) { 
            GameObject temp = Instantiate(banana, new Vector3(Random.Range(-50, 50), 2.5f, Random.Range(-50, 50)), Quaternion.identity);
            temp.transform.parent = this.transform;
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
