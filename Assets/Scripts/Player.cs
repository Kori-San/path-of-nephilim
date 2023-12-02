using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Form
{
    public const string Angel = "Ange";
    public const string Devil = "Demon";
}

public class Player : MonoBehaviour
{
    private Rigidbody2D playerRigidbody;
    private SpriteRenderer playerSpriteRenderer;

    private int maxJump;
    private int currJump = 0;

    private int gems = 0;

    private string form; 
    public Sprite devilSprite;
    public Sprite angelSprite;

    private float jumpVelocity = 25.5f;

    private void switchForm()
    {
        if (form == Form.Angel)
        {
            form = Form.Devil;
            playerSpriteRenderer.sprite = devilSprite;
            maxJump = 1;
        }
        else
        {
            form = Form.Angel;
            playerSpriteRenderer.sprite = angelSprite;
            maxJump = 2;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        playerSpriteRenderer = GetComponent<SpriteRenderer>();
        switchForm();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            switchForm();
        }
        if (Input.GetButtonDown("Jump") && currJump < maxJump)
        {
            playerRigidbody.velocity = new Vector2(playerRigidbody.velocity.x, jumpVelocity);
            currJump++;
        } 
    }

    public string getForm()
    {
        return form;
    }
    
    public void die()
    {
        string sceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(sceneName);
    }

    public int getGems()
    {
        return gems;
    }

    public void addGem()
    {
        gems++;
        Debug.Log("Gems: " + gems.ToString());
    }

    public void resetJump()
    {
        currJump = 0;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        /* Checking if the player is on the ground. */
        if (collision.contacts[0].point.y <= transform.position.y)
        {
            resetJump();
        }
    }
}
