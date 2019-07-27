using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomOut : MonoBehaviour
{

    public Camera zoomCam;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse1)) {
            SwitchCamera();
        }
    }

    void SwitchCamera() {
        transform.position = zoomCam.transform.position;
        GetComponent<Camera>().orthographicSize = zoomCam.orthographicSize;
    }

}
