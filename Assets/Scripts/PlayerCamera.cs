using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] Transform target;

    public Vector3 offset;
    public float zoomSpeed = 4f;
    public float minZoom = 5f;
    public float maxZoom = 15f;
    public float pitch = 2f;
    private float currZoom = 10f;

    public float camSpeed = 100f;
    private float camInput = 0f;
    private float camInput2 = 0f;

    void Update() 
    {
        currZoom -= Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
        currZoom = Mathf.Clamp(currZoom, minZoom, maxZoom);

        camInput -= Input.GetAxis("Horizontal") * camSpeed * Time.deltaTime;
    }
    void LateUpdate()
    {
        transform.position = target.position - offset * currZoom;
        transform.LookAt(target.position + Vector3.up * pitch);

        transform.RotateAround(target.position, Vector3.up, camInput);
    }
}
