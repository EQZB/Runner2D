using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    
    //public Transform cam;
    public MeshRenderer bgRenderer;
    public float relMovement = 0.3f;

    private void Awake(){

      bgRenderer = GetComponent<MeshRenderer>();
    }

  
    
       // Update is called once per frame
    private void Update()
    {
      
      float gmGameSpeed = GameManager.Instance.gameSpeed / transform.localScale.x;
      bgRenderer.material.mainTextureOffset += Vector2.right * relMovement * (gmGameSpeed) * Time.deltaTime;

      //transform.position = new Vector2(cam.position.x * relMovement, 0f);
        
    }
}
