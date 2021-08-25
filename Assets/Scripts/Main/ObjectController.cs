using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectController : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 200f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            transform.Rotate((Input.GetAxis("Mouse Y") * rotationSpeed * Time.deltaTime), (-Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime), 0, Space.World);
        }
            

    }
}
