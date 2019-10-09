using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private int score;
    public Spawner[] spawners;
    public int waveNo;
    public float timeBetweenWaves;
    private GenericTimer timer;
    [SerializeField]
    private int numberSpawned;
    [SerializeField]
    private GameObject[] objects;

    [SerializeField]
    private GameObject player1;
    [SerializeField]
    private GameObject player2;
    [SerializeField]
    private int reviveCost;
    public Texture Crosshair;
    public Text waveText;
    public Text scoreText;
    public GameObject endScreen;
    [SerializeField]
    private Text endText;

    private int numDead = 0;
    
    private int noDeaths;

    /*
     * Manages most aspects of the game set up
     * i.e. Players, spawners, scores, etc
     */
    private void Start()
    {
        timer = new GenericTimer(10, false);
        if (isMultiplayer())
        {
            player1.GetComponentInChildren<Camera>().rect = new Rect(0,0,0.5f,1);
            player2.GetComponentInChildren<Camera>().rect = new Rect(0.5f,0,0.5f,1);
            AudioListener listener = player2.GetComponentInChildren<Camera>().GetComponent<AudioListener>();
            if(listener != null)
                listener.enabled = false;
            player2.transform.parent = null;
        }

        player1.transform.parent = null;
        
    }

    /*
     * Spawns the enemies
     * Updates the common UI
     */
    private void FixedUpdate()
    {
        if (timer == null) return;
        waveText.text = "Next wave: " + (int)(timer.getTimeLeft());
        if (timer.isTimeout())
        {
            waveText.text = "Wave: " + waveNo;
            noDeaths = 0;
            timer = null;
            
            numberSpawned += waveNo + waveNo/2;
            numberSpawned = (numberSpawned / spawners.Length);
            numberSpawned *= spawners.Length;
            foreach (var spawner in spawners)
            {
                spawner.spawnObjects(numberSpawned/spawners.Length, objects);
            }
        }
    }
    
    /*
     * Creates crosshairs for the players
     */
    private void OnGUI()
    {
        float xMin = (Screen.width / (isMultiplayer()?4:2)) - (Crosshair.width / 2);
        float yMin = (Screen.height / 2) - (Crosshair.height / 2);
        
        GUI.DrawTexture(new Rect(xMin, yMin, Crosshair.width, Crosshair.height), Crosshair);
        if(isMultiplayer())
            GUI.DrawTexture(new Rect(xMin + Screen.width/2.0f, yMin, Crosshair.width, Crosshair.height), Crosshair);
    }

    /*
     * Records death of enemy to make sure wave is done
     */
    public void recordDeath(int addScore)
    {
        changePoints(addScore);
        noDeaths++;
        if(numberSpawned <= noDeaths)
            endWave();
    }

    /*
     * Sets up the new wave
     */
    private void endWave()
    {
        waveNo++;
        timer = new GenericTimer(timeBetweenWaves, false);
    }

    /*
     * Adds points to the counter
     */
    public void changePoints(int amount)
    {
        score += amount;
        scoreText.text = "Points " + score;
    }

    /*
     * Getter for the 
     */
    public int getScore()
    {
        return score;
    }

    public bool isMultiplayer()
    {
        return player2 != null && player2.activeSelf;
    }

    public bool waveInProgress()
    {
        return timer == null;
    }

    public void revivePlayer()
    {
        numDead--;
    }
    
    public void playerDead()
    {
        if (isMultiplayer())
        {
            numDead++;
            if (numDead >= 2)
                endGame();
        }
        else
        {
            endGame();
        }
    }

    private void endGame()
    {
        scoreText.gameObject.SetActive(false);
        waveText.gameObject.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0.01f;
        endText.text = "Wave " + waveNo;
        endScreen.gameObject.SetActive(true);
    }

    public bool tryRevive()
    {
        if (getScore() < reviveCost) return false;
        
        changePoints(-1 * reviveCost);
        return true;
    }
}
