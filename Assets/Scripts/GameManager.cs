using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public GameObject mainCamera;

    public float initialSpeed = 5f;
    public float increasingSpeed = 0.0125f;
    public int frameCycle = 100;
    public float cameraSpeedFactor = 0.02f;

    private float speed;
    private int frameCount = 0;
    private Rigidbody2D playerRB;


    // Start is called before the first frame update
    void Start()
    {
        playerRB = player.GetComponent<Rigidbody2D>();
        speed = initialSpeed;
    }

    private bool IsVisible(Camera c, GameObject target)
    {
        var planes = GeometryUtility.CalculateFrustumPlanes(c);
        var point = target.transform.position;

        foreach (var plane in planes)
        {
            if (plane.GetDistanceToPoint(point) < 0)
            {
                return false;
            }
        }

        return true;
    }

    /// This function changes the text value of a TextMeshProUGUI component in a given GameObject or its
    /// child object.
    /// 
    /// Args:
    ///   GameObject: The initial game object that contains the TextMeshProUGUI component that needs to be
    ///               changed.
    ///   label (string): The name of the child object whose TextMeshProUGUI component needs to be changed.
    ///                   If label is an empty string, then the TextMeshProUGUI component of the initialObject's
    ///                   first child will be changed.
    ///   textValue (string): The new text value that will be assigned to the TextMeshProUGUI component.
    /// 
    /// Returns:
    ///   The method is returning nothing (void).
    private void ChangeChildTextMeshPro(GameObject initialObject, string label, string textValue)
    {
        GameObject finalObject = initialObject.transform.Find(label).gameObject;
        TextMeshProUGUI objectText = label == "" ? initialObject.GetComponentInChildren<TextMeshProUGUI>() : finalObject.GetComponent<TextMeshProUGUI>();
        objectText.text = textValue;

        return;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        mainCamera.transform.Translate(speed * cameraSpeedFactor, 0, 0);

        if (!IsVisible(mainCamera.GetComponent<Camera>(), player))
        {
            player.GetComponent<Player>().die();
        }

        playerRB.velocity = new Vector2(speed, playerRB.velocity.y);
        speed = ++frameCount % frameCycle == 0 ? speed + increasingSpeed : speed;

        ChangeChildTextMeshPro(mainCamera, "", "Gems: " + player.GetComponent<Player>().getGems().ToString());
    }
}
