using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private string name;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player")) {
            GameObject.Find("GameManager").GetComponent<GameManager>().xp += 20;
            Destroy(this.gameObject);

            GameObject.Find("GameManager").GetComponent<GameManager>().addItem(name);
        }
    }

}
