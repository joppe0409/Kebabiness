using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class LevelSelectionScript : MonoBehaviour
{
    public void startLevel(string level) 
    {
        SceneManager.LoadScene(level);
    }
}
