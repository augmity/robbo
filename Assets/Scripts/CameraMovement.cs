using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform target;
    public float smoothing;

    void LateUpdate()
    {
        if (transform.position != target.position)
        {
            Vector3 targetPosition = new Vector3(
                transform.position.x,
                Mathf.Clamp(target.position.y, -23.5f, -6.5f),
                transform.position.z
            );
            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing);
        }
    }
}
