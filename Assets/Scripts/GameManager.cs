using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;

public class GameManager : MonoBehaviour
{
    public static GameManager i;
    public Ball ball;

    public List<GameObject> allLevels;
    public GameObject[] allBricks;

    GameObject currentLevelObject;

    public Transform gameOverPannel;
    public Transform nextLevelPannel;
    public Transform winPannel;

    bool levelPassed;
    bool gameOver;

    public TMP_Text scoreText;
    public TMP_Text livesText;

    public int numBricks;
    public int currentLevel = 0;
    [SerializeField] int score;
    [SerializeField] int numLives;

    public bool LevelPassed()
    {
        return levelPassed;
    }
    private void Awake()
    {
        if (i == null) i = this;
        else Destroy(i);
    }
    private void Start()
    {
        LoadLevel();
        scoreText.text = "Score: " + score;
        livesText.text = "Lives: " + numLives;
    }
    private void CountInitialBricks()
    {
        allBricks = GameObject.FindGameObjectsWithTag("Brick");
        for(int i = 0; i < allBricks.Length; i++)
        {
            var infiniteBrick = allBricks[i].GetComponent<InfiniteBrick>();
            if (!infiniteBrick) numBricks++;
        }
    }
    public void UpdateNumBricks()
    {
        numBricks--;
        if (numBricks == 0)
        {
            LevelCleared();
            if (currentLevel < allLevels.Count)
            {
                Invoke("LoadLevel", 3f);
            }
        }
    }
    private void LoadLevel()
    {
        currentLevelObject = Instantiate(allLevels[currentLevel], Vector2.zero, Quaternion.identity);
        levelPassed = false;
        nextLevelPannel.gameObject.SetActive(false);
        CountInitialBricks();
    }
    private void LevelCleared()
    {
        levelPassed = true;
        CleanUpLevel();
        currentLevel++;
        if (currentLevel >= allLevels.Count)
        {
            winPannel.gameObject.SetActive(true);
        } else
        {
            nextLevelPannel.gameObject.SetActive(true);
            nextLevelPannel.GetComponentInChildren<TMP_Text>().text = "Loading Level " + currentLevel;
        }
    }
    private void CleanUpLevel()
    {
        currentLevelObject.SetActive(false);
    }
    public void UpdateScore(int scoreValue)
    {
        score += scoreValue;
        scoreText.text = "Score: " + score;
    }
    public void UpdateNumLives(int value = -1)
    {
        numLives += value;
        livesText.text = "Lives: " + numLives;
        if (numLives == 0)
        {
            GameOver();
        }
    }
    private void GameOver()
    {
        gameOver = true;
        gameOverPannel.gameObject.SetActive(true);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}