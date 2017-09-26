using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class GameController : MonoBehaviour {

    public GameObject[] hazards;
    public Vector3 spawnValues;
    public int hazardCount;
    public int hazardIncrease;
    public float spawnWait;
    public float startWait;
    public float waveWait;

    public Text scoreText;
    public Text restartText;
    public Text gameOverText;
    private int score;
    private int wavesSurvived;

    private bool gameOver, restart;

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);

        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                GameObject hazard = hazards[Random.Range(0, hazards.Length)];
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
                if(gameOver)
                {
                    break;
                }
            }
            hazardCount += hazardIncrease;
            yield return new WaitForSeconds(waveWait);

            if(gameOver)
            {
                restartText.text = "Press 'R' to restart";
                restart = true;
                break;
            }
            wavesSurvived += 1;
        }
    }

    void UpdateScore ()
    {
        scoreText.text = "Score : " + score;
    }

    public void AddScore(int value)
    {
        score += value;
        UpdateScore();
    }

    public void GameOver()
    {
        gameOverText.text = "Game Over !\nFinal Score : "+score+"\nWaves survived : "+wavesSurvived;
        gameOver = true;
    }

    private void Start()
    {
        gameOver = false;
        restart = false;

        restartText.text = "";
        gameOverText.text = "";

        score = 0;
        wavesSurvived = 0;
        UpdateScore();
        StartCoroutine(SpawnWaves());
    }

    private void Update()
    {
        if(restart)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }
}
