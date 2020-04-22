using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimRaycast : MonoBehaviour {
    
    private LineRenderer lineRenderer;

    void Start() {
        lineRenderer = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update() {
        Vector3 rayPos = transform.position + new Vector3(0, 1.7f, 0) + (transform.forward * 2f);
        // Vector3 rayPos = transform.position + new Vector3(0, 1, 0);
        lineRenderer.SetPosition(0, rayPos);
        RaycastHit hit;
        if (Physics.Raycast(rayPos, transform.forward, out hit)) {
            // if (hit.collider.tag == "Wall" || hit.collider.tag == "Player") {
            if (hit.collider) {
                lineRenderer.SetPosition(1, hit.point);
            }
            else {
                lineRenderer.SetPosition(1, rayPos + (transform.forward * 5000));
            }
        }
    }
}
