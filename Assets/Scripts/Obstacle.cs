using UnityEngine;


public class Obstacle : MonoBehaviour
{

    private float leftEdge;

    //to replace with gamespeed
    public float speed;
    
    // Start is called before the first frame update
    private void Start()
    {
        leftEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 2f;
        
    }

    // Update is called once per frame
    private void Update()
    {
        
        
        transform.position += Vector3.left * speed * GameManager.Instance.gameSpeed * Time.deltaTime;

        if (transform.position.x < leftEdge) {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other){

        if (other.CompareTag("Player")) {
            GameManager.Instance.GameOver();
        }

    }
}
