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
    public float pitch = 0f;
    private float currZoom = 10f;

    public float camSpeed = 100f;
    private float camInput = 180f;
    private float camInput2 = 0f;

    public bool isMoving = true;

    void Update() 
    {
        currZoom -= Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
        currZoom = Mathf.Clamp(currZoom, minZoom, maxZoom);
    }
    void LateUpdate()
    {
        if (isMoving == true)
        {
            camInput -= Input.GetAxis("Horizontal") * camSpeed * Time.deltaTime;
            camInput2 -= Input.GetAxis("Vertical") * camSpeed * Time.deltaTime;
            
            transform.position = target.position - offset * currZoom;
            
            transform.LookAt(target.position + Vector3.up * pitch);
            transform.RotateAround(target.position, Vector3.up, camInput);
            transform.RotateAround(target.position, Vector3.right, camInput2);
        }
    }
}
