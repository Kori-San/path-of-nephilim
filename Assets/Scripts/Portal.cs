using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
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
            int next_scene = SceneManager.GetActiveScene().buildIndex + 1;
            int max_scene = SceneManager.sceneCountInBuildSettings - 1;
            if (next_scene <= max_scene)
            {
                SceneManager.LoadScene(next_scene);
            }
            else
            {
                SceneManager.LoadScene(0);
            }
        }
    }
}
