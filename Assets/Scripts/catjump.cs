
using UnityEngine;

public class Catjump : MonoBehaviour
{
    
    public float JumpStrength;

    public int jumpcount = 0;

    [SerializeField]
    bool isRun = false;

    Rigidbody2D RB;

    private void Awake(){

        RB = GetComponent<Rigidbody2D>();
    }


    
    // Update is called once per frame
    void FixedUpdate()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            
            if(jumpcount < 2){

                if(isRun == true){

                    RB.AddForce(Vector2.up * JumpStrength);
                    jumpcount += 1;
                }

            if(jumpcount >= 2){
                isRun = false;
                jumpcount *= 0;
            }

            
                
                

            }
            
        }
    }

   

    private void OnCollisionEnter2D(Collision2D collision){

        if(collision.gameObject.CompareTag("ground")){
            if(isRun == false){
                isRun = true;
            
            }
        }

    }
}
