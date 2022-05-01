using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private void Awake()
    {
        if(GameManager.instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        SceneManager.sceneLoaded += LoadState;
        DontDestroyOnLoad(gameObject);
    }

    //Resources
    public List<Sprite> playerSprites;
    public List<Sprite> toolSprites;
    public List<int> shopPrices;

    //References
    public Player player;

    //Logic
    public int money;

    //Save Game
    /*
     * int preferredCharacter
     * int money
     */
    public void SaveState()
    {
        string save = "";
        save += "0" + "|";
        save += money.ToString();
        PlayerPrefs.SetString("SaveState", save);
    }

    //Load Game
    public void LoadState(Scene s, LoadSceneMode mode)
    {
        if (!PlayerPrefs.HasKey("SaveState"))
        {
            return;
        }
        string[] data = PlayerPrefs.GetString("SaveState").Split('|');

        //sprite
        money = int.Parse(data[1]);
    }
}
