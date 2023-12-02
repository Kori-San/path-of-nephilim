using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            GameObject playerGameObject = collision.gameObject;
            Player player = playerGameObject.GetComponent<Player>();
            player.addGem();

            Destroy(gameObject);
        }
    }
}
