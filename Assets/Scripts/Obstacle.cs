using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Obstacle : MonoBehaviour
{

    public bool blockDevil = false;
    public bool blockAngel = false;
    public bool killDevil = false;
    public bool killAngel = false;

    public CompositeCollider2D obstacleCollider;

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

            string form = player.getForm();

            if ((killAngel && form == Form.Angel) || (killDevil && form == Form.Devil))
            {
                player.die();
            }

            if ((blockAngel && form == Form.Angel) || (blockDevil && form == Form.Devil))
            {
                obstacleCollider.isTrigger = false;
                player.resetJump();
            }
        }
    }
}
