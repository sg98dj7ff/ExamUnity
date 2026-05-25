using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OllisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // логика добавления счета и удаления монеты
        }      
    }
}
