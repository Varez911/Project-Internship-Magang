using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectController : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 5f;
    public float zoomOutMin = 1;
    public float zoomOutMax = 8;
   
    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            if (Input.touchCount == 1)
            {
                float pointer_x = Input.touches[0].deltaPosition.x;
                float pointer_y = Input.touches[0].deltaPosition.y;
                transform.Rotate((pointer_y * rotationSpeed * Time.deltaTime),
                    (-pointer_x * rotationSpeed * Time.deltaTime), 0, Space.World);
            }

            if (Input.touchCount == 2)
            {
                Touch touchZero = Input.GetTouch(0);
                Touch touchOne = Input.GetTouch(1);

                Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
                Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

                float prevMagnitude = (touchZeroPrevPos - touchOnePrevPos).magnitude;
                float currentMagnitude = (touchZero.position - touchOne.position).magnitude;

                if (currentMagnitude == prevMagnitude)
                {
                    Debug.Log("Pan");
                }
                else
                {
                    Debug.Log("Zoom");
                    float difference = currentMagnitude - prevMagnitude;
                    zoom(difference * 0.01f);
                }

            }
        }
        
        void zoom(float increment){
            Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize - increment, zoomOutMin, zoomOutMax);
        }
    }
}
