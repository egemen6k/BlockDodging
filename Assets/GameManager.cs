using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private float _slowness = 10f;
    public void EndGame()
    {
        StartCoroutine(RestartLevel());
    }

    IEnumerator RestartLevel()
    {
        Time.timeScale = 1/_slowness;
        Time.fixedDeltaTime = Time.fixedDeltaTime / _slowness;

        yield return new WaitForSeconds(1f / _slowness);

        Time.timeScale = 1;
        Time.fixedDeltaTime = Time.fixedDeltaTime * _slowness;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
