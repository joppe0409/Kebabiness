using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class LevelSelectionScript : MonoBehaviour
{
    public void startLevel(string level) 
    {
        SceneManager.LoadScene(level); // H�r "loadar" vi v�ran scen och byter till den angivna scenen i unity. - Freja Holmgren Jakobsson.
        
    }
}
