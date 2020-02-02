using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{

    static public SceneChanger i;
    private void Awake()
    {
        if (!i)
        {
            i = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public int current = 0;
    public int[] levels = {1,2,3,4,5,6};
    public void LoadNextLevel()
    {
        current += 1;
        if(current > levels.Length)
        {
            SceneManager.LoadScene ("Final");
        }
        else
        {
            SceneManager.LoadScene ("level_"+current);
        }
        

    }
    public void RestartLevel()
    {
        SceneManager.LoadScene ("level_"+current);
    }
    public void LoadMainMenu()
    {
        current = 0;
        SceneManager.LoadScene ("MainMenu");
    }
}
