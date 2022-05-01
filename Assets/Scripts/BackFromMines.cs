using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackFromMines : MonoBehaviour
{
    public void ToFarm()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("SpringFarm");
    }
}
