using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMovement : MonoBehaviour
{
    
    public float cameraSpeed;
    
    
    // Update is called once per frame
    void Update()
    {
        float gmGameSpeed = GameManager.Instance.gameSpeed / transform.localScale.x;
        transform.position -= new Vector3(cameraSpeed * gmGameSpeed * Time.deltaTime, 0, 0);

        if (transform.position.x < -50f){
            cameraSpeed = 0f;
        }
    }
}
