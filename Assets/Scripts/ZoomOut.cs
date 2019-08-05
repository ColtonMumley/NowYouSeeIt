using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomOut : MonoBehaviour
{

    public float zoom = 50f;
    public float normal = 20f;
    public float smooth = 6f;
    private bool isZoomed;

    // Start is called before the first frame update
    void Start()
    {
        isZoomed = false;
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetMouseButtonDown(1)) {
            isZoomed = !isZoomed;
        }
        if (Input.GetMouseButtonUp(1)) {
            isZoomed = !isZoomed;
        }
        if (isZoomed) {
            GetComponent<Camera>().orthographicSize = Mathf.Lerp(GetComponent<Camera>().orthographicSize, zoom, Time.deltaTime * smooth);
        } else {
            GetComponent<Camera>().orthographicSize = Mathf.Lerp(GetComponent<Camera>().orthographicSize, normal, Time.deltaTime * smooth);
        }
    }
}
