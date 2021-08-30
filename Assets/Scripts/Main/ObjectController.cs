using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectController : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 5f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            float pointer_x = Input.touches[0].deltaPosition.x;
            float pointer_y = Input.touches[0].deltaPosition.y;
            transform.Rotate((pointer_y * rotationSpeed * Time.deltaTime), (-pointer_x * rotationSpeed * Time.deltaTime), 0, Space.World);
        }
            

    }
}
