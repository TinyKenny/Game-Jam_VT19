using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController GameControllerInstance;

    public float score = 0.0f;
    public Text scoreText;

    public GameObject[] straightPipes; // done
    public GameObject[] cornerPipes; // done
    public GameObject[] caltropPipes; // done
    public GameObject[] crossingPipes; // done
    public GameObject[] tCrossingPipes; // done
    public GameObject[] doubleTCrossingPipes; // done
    public GameObject[] muhsroomPipes; // done


    // Start is called before the first frame update
    void Start()
    {
        score = PlayerPrefs.GetFloat("Score");
        PlayerPrefs.SetFloat("Score", 0.0f);
        GameControllerInstance = this;
        scoreText.text = "Score: " + (int)score;
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name.Equals("SampleScene"))

        score += Time.deltaTime;

        scoreText.text = "Score: " + (int)score;

    }

    public void GameOver()
    {
        PlayerPrefs.SetFloat("Score", score);

        SceneManager.LoadScene(1);

    }
}
