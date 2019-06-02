using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManagerSingleton : Singleton<LevelManagerSingleton>
{
    public enum SpawnState { SPAWNING, WAITING, WAITUSERINPUT }
    // (Optional) Prevent non-singleton constructor use.
    protected LevelManagerSingleton()
    {

    }

    public int waves; //the # of levels created
    private int nextWave = 1;
    [SerializeField] Text infoText;
    
    private GameObject[] enemiesLeft;

    [HideInInspector] SpawnState state = SpawnState.WAITUSERINPUT;

    private void Start()
    {

    }

    private void Update()
    {
        switch (state)
        {
            case SpawnState.SPAWNING:
                //Debug.Log("state = spawning");
                LoadSceneAdditive("Wave" + nextWave.ToString());
                nextWave++;
                state = SpawnState.WAITING;
                break;
            case SpawnState.WAITING:
                //Debug.Log("state = waiting");
                enemiesLeft = GameObject.FindGameObjectsWithTag("Enemy");
                infoText.text = "There are " + enemiesLeft.Length + " enemies remaining.\nWave " + (nextWave - 1) + "/" + waves;
                if (enemiesLeft.Length <= 0)
                    state = SpawnState.WAITUSERINPUT;
                break;
            case SpawnState.WAITUSERINPUT:
                //Debug.Log("state = waituserinput");
                if(nextWave > waves)
                {
                    infoText.text = "Congratulations! you beat all the waves!";
                    if (Input.GetKeyDown(KeyCode.Space))
                        SceneManager.LoadScene(0);

                    break;
                }
                infoText.text = "Press Spacebar to start wave " + nextWave;
                if (Input.GetKeyDown(KeyCode.Space))
                    state = SpawnState.SPAWNING;
                break;
            default:
                break;
        }
    }

    public void LoadSceneAdditive(string sceneName)
    {
        SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
    }
}
