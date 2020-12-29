using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RawThirdPersonCamera : MonoBehaviour
{
    [SerializeField] Vector3 camOffset = Vector3.zero;
    [SerializeField] float camSpeed, camHeight, angle;
    [SerializeField] TouchFields touchPad;

    private void Update() {
        // Increase angle as much as the TouchDistance in X-axis
        //   angle multiply by speed to make the camera move faster
        angle += touchPad.TouchDistance.x * camSpeed;
        // Move the main camera around the player position
        // Multiply the rotations in Vector3.up according angle with the offset
        Camera.main.transform.position = transform.position + Quaternion.AngleAxis(angle, Vector3.up) * camOffset;
        // Multiply the Vector3.up (0,1,0) with the cameraHeight (camHeight)
        //   Transforming the camHeight to a Vector3 with 0 values in X and Z axis
        // substract the new camHeight with the current camera positions
        //   Getting an offset for rotations
        Vector3 rotOffset = Vector3.up * camHeight - Camera.main.transform.position;
        Camera.main.transform.rotation = Quaternion.LookRotation(transform.position + rotOffset, Vector3.up);
    }
}
