using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFowllowing : MonoBehaviour
{
    public Transform target;
    public float smoothing;
    private float lowY;
    Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - target.position;
        lowY = transform.position.y;
    }
    void FixedUpdate()
    {
        Vector3 CamPosUpdate = offset + target.position;
        transform.position = Vector3.Lerp(transform.position, CamPosUpdate, smoothing * Time.deltaTime);

        if ((transform.position.y > lowY) || (transform.position.y < lowY))
        {
            transform.position = new Vector3(transform.position.x, lowY, transform.position.z);
        }
    }
}
