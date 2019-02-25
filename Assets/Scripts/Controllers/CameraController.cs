using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Vector3 cameraOriginPoint;
    private Vector3 offset;
    private bool _dragging;

    [SerializeField] private float _minZoom = 2.5f;
    [SerializeField] private float _maxZoom = 50f;
    [SerializeField] private Transform _myTransform;
    //change size to zoom in/out
    //clamp values to min and max
    //mouse wheel scrolling

    private void LateUpdate()
    {
        Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize -= Input.GetAxis("Mouse ScrollWheel") * (Camera.main.orthographicSize), _minZoom, _maxZoom);
        CameraDrag();
    }

    void CameraDrag()
    {
        if(Input.GetButton("Fire2"))
        {
            offset = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - _myTransform.position);
            if(!_dragging)
            {
                _dragging = true;
                cameraOriginPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }
        }
        else
        {
            _dragging = false;
        }
        if(_dragging)
        {
            _myTransform.position = cameraOriginPoint - offset;
        }
    }
}
