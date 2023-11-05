using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Player player;

    public float initialSpeed = 5f;
    public float increasingSpeed = 0.0125f;
    public int frameCycle = 100;

    private float speed;
    private int frameCount = 0;
    private Rigidbody2D playerRB;


    // Start is called before the first frame update
    void Start()
    {
        playerRB = player.GetComponent<Rigidbody2D>();
        speed = initialSpeed; 
    }

    // Update is called once per frame
    void Update()
    {
        playerRB.velocity = new Vector2(speed, playerRB.velocity.y);
        speed = ++frameCount % frameCycle == 0 ? speed + increasingSpeed : speed;
    }
}
