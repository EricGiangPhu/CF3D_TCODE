using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManger : MonoBehaviour {

    public static int CountEnemy = 0;
    [SerializeField] GameObject _prefEnemy;
    [SerializeField] Transform[] _pRandomEnemy;

    [SerializeField] Transform _player;

    IEnumerator DelayCreateEnemy () {

        float timeDelay = Random.Range (1.0f, 3.0f);
        yield return new WaitForSeconds (timeDelay);

        //clone enemy from prefab
        createEnemy ();

        //loop create enemy
        StartCoroutine (DelayCreateEnemy ());
    }
    // Start is called before the first frame update
    void Start () {
        StartCoroutine (DelayCreateEnemy ());
    }

    // Update is called once per frame
    void Update () {

    }

    void createEnemy () {
        if (CountEnemy > 4) {
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
}