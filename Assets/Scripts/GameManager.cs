
using UnityEngine;
using TMPro;
using UnityEngine.UI;




public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }


    public float initialGameSpeed = 2.5f;
    public float gameSpeedIncrease = 0.0005f;
    public float gameSpeed { get; private set; }

    private CatBehavior klot;
    private Spawner spawner;

    
    public TextMeshProUGUI gameOverText;
    public Button retryBut;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI hiScoreText;
    private float score;
    private float hiscore;

    public void Awake(){

        

        if (Instance == null){
            Instance = this;
        } else{
            DestroyImmediate(gameObject);
        }
    }

    private void OnDestroy(){

        if (Instance == this) {
            Instance = null;
        }
    }

    private void Start(){

        klot = FindObjectOfType<CatBehavior>();
        spawner = FindObjectOfType<Spawner>();
        
        NewGame();
    }

    public void NewGame(){

        
        Obstacle[] obstacles = FindObjectsOfType<Obstacle>();

        foreach (var obstacle in obstacles) {
            Destroy(obstacle.gameObject);
        }

        gameSpeed = initialGameSpeed;
        enabled = true;

        klot.gameObject.SetActive(true);
        spawner.gameObject.SetActive(true);
        gameOverText.gameObject.SetActive(false);
        retryBut.gameObject.SetActive(false);
        score = 0;
        scoreText.text = Mathf.FloorToInt(score).ToString();

        HiScoreUpdate();
        
        
    }

    public void GameOver(){

        gameSpeed = 0f;
        enabled = false;

        klot.gameObject.SetActive(false);
        spawner.gameObject.SetActive(false);
        gameOverText.gameObject.SetActive(true);
        retryBut.gameObject.SetActive(true);

        HiScoreUpdate();


    }

    private void Update(){

        gameSpeed += gameSpeedIncrease * Time.deltaTime;
        score += gameSpeed * Time.deltaTime;
        scoreText.text = Mathf.FloorToInt(score).ToString();
        
    }

    private void HiScoreUpdate(){

        float hiscore = PlayerPrefs.GetFloat("hiscore",0);

        if(score > hiscore){

            hiscore = score;
            PlayerPrefs.SetFloat("hiscore", hiscore);
        }

        hiScoreText.text= Mathf.FloorToInt(hiscore).ToString();

    }

   
}
