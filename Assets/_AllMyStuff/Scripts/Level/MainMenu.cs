using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void LoadWaveLevel()
    {
        SceneManager.LoadScene(1);
    }
    public void LoadDungeonLevel()
    {
        SceneManager.LoadScene(2);
    }
}
