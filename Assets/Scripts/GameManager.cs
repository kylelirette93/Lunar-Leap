using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    


    public void PlayButtonClicked()
    {
        SceneManager.LoadScene("Level01");
    }

    public void ExitButtonClicked()
    {
        Application.Quit();
    }
   
}
