using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ColorManager : MonoBehaviour
{

    public GameObject player;
    public Camera mainCam;

    // Start is called before the first frame update
    void Start()
    {
        disablePlatforms(Color.black, Color.white);
    }

    // Update is called once per frame
    void Update()
    {
        // If left click and not hovering over a button
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject()) {
            SwitchColors();
        }
            
    }

    // Reset level back to original colors
    public void Reset() {
        player.GetComponent<SpriteRenderer>().color = Color.white;
        mainCam.backgroundColor = Color.black;
        disablePlatforms(Color.black, Color.white);
    }

    // Changes Player and Background colors
    void SwitchColors() {
        if (player.GetComponent<SpriteRenderer>().color == Color.white) {
            player.GetComponent<SpriteRenderer>().color = Color.black;
            disablePlatforms(Color.white, Color.black);
        } else {
            player.GetComponent<SpriteRenderer>().color = Color.white;
            disablePlatforms(Color.black, Color.white);
        }
        if (mainCam.backgroundColor == Color.white) {
            mainCam.backgroundColor = Color.black;
        } else {
            mainCam.backgroundColor = Color.white;
        }
    }

    // Disables colliders on any platform with color of disableColor,
    // and enables colliders on any platform with color of enableColor
    void disablePlatforms(Color disableColor, Color enableColor) {
        GameObject[] platforms = GameObject.FindGameObjectsWithTag("Ground");
        foreach(GameObject platform in platforms) {
            if (platform.GetComponent<SpriteRenderer>().color == disableColor) {
                platform.GetComponent<EdgeCollider2D>().enabled = false;
            } else {
                platform.GetComponent<EdgeCollider2D>().enabled = true;
            }
        }
    }
}
