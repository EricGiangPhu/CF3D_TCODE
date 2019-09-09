using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManger : MonoBehaviour {

    public static int CountEnemy = 0;
    public static bool isGameOver = false;

    [SerializeField] GameObject _prefEnemy;
    [SerializeField] Transform[] _pRandomEnemy;

    [SerializeField] Transform _player;

    [SerializeField] GameObject _dialogGameOver;
    [SerializeField] Text _lblScore;
    [SerializeField] Text _lblCurrentScore;

    int score = 0;

    IEnumerator DelayCreateEnemy () {
        for (;;) {
            float timeDelay = Random.Range (1.0f, 3.0f);
            yield return new WaitForSeconds (timeDelay);
            //clone enemy from prefab
            createEnemy ();
        }
    }
    // Start is called before the first frame update
    void Start () {
        isGameOver = false;
        StartCoroutine (DelayCreateEnemy ());
        _dialogGameOver.SetActive (false);
        
        //set score when start game
        UpdateTextCurrentScore ();
    }

    public void ShowGameOver () {
        //
        isGameOver = true;

        // 1. show score
        string stringScore = "Score: " + score;
        _lblScore.text = stringScore;

        // show dialog game over
        _dialogGameOver.SetActive (true);
    }

    void createEnemy () {
        if (CountEnemy > 4) {
            return;
        }

        //end game
        if (GameManger.isGameOver) {
            return;
        }

        // 1. Ramdom point init enemy
        // 2. Instantiate to clone enemy from prefabs
        // 3. set target for enemy

        //1
        int index = Random.Range (0, _pRandomEnemy.Length);
        Transform p = _pRandomEnemy[index];

        //2
        GameObject enemyObject = Instantiate (_prefEnemy, p.position, Quaternion.identity);

        //3
        Enemy e = enemyObject.GetComponent<Enemy> ();
        e.SetTarget (_player);
    }

    public void IncreateScore () {
        score++;

        UpdateTextCurrentScore ();
    }

    public void UpdateTextCurrentScore () {
        string stringScore = "Score: " + score;
        _lblCurrentScore.text = stringScore;
    }

    public void BulletCallback_RestartGame () {
        // using SceneManager
        SceneManager.LoadScene (0);
    }
}