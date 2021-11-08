using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject player;
    void Start()
    {
        Time.timeScale = 0;
    }


    public void GameStart()
    {
        Time.timeScale = 1;
        this.gameObject.SetActive(false);
        player.gameObject.GetComponent<PlayerController>().enabled = true;
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }

}
