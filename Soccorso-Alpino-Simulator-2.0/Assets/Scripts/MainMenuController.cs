using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    [SerializeField]
    private Scene _baita;

    [SerializeField]
    private Scene _montagna;


    //Fare solo una funzione per caricare la scena con un parametro che dice se è game o no

    public void PlayElicopter()
    {
        SceneManager.LoadSceneAsync(_baita.handle);

    }

    public void PlayDog()
    {
        SceneManager.LoadSceneAsync(_baita.handle);

    }

    public void PlaySnow()
    {
        SceneManager.LoadSceneAsync(_montagna.handle);

    }


    public void PlayElicopterGame()
    {
        SceneManager.LoadSceneAsync(_baita.handle);

    }

    public void PlayDogGame()
    {
        SceneManager.LoadSceneAsync(_baita.handle);

    }

    public void PlaySnowGame()
    {
        SceneManager.LoadSceneAsync(_montagna.handle);

    }
    public void QuitGame()
    {
        Application.Quit();
    }


    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

}
