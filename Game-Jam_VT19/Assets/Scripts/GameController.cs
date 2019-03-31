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
        GameControllerInstance = this;
    }

    // Update is called once per frame
    void Update()
    {

        score += Time.deltaTime;

        scoreText.text = "Score: " + (int)score;

    }

    public void GameOver()
    {


        SceneManager.LoadScene(1);

    }
}
