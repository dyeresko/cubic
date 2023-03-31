using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform playerTransform;
    public Vector3 cameraOffset;

    void LateUpdate()
    {
        // calculate new camera position
        Vector3 newPos = new Vector3(playerTransform.position.x, 0, playerTransform.position.z) + cameraOffset;
        // set camera position
        transform.position = newPos;
        // set camera rotation

        transform.rotation = Quaternion.Euler(30, 45, 0);
    }
}
