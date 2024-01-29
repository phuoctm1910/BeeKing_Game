using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Navigation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void OpenLevelSelection()
    {
        SceneManager.LoadScene("LevelSelection");
    }
    public void OpenLevel1()
    {
        SceneManager.LoadScene("Level1");
    }
    public void OpenLevel2() 
    {
        SceneManager.LoadScene("Level2");
    }
    public void OpenLevel3()
    {
        SceneManager.LoadScene("Level3");
    }
    public void OpenChapter1()
    {
        SceneManager.LoadScene("Chapter1");
    }
    public void OpenChapter2()
    {
        SceneManager.LoadScene("Chapter2");
    }
    public void OpenChapter3()
    {
        SceneManager.LoadScene("Chapter3");
    }
}
