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

    private int numDead = 0;
    
    private int noDeaths;

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
    
    private void OnGUI()
    {
        float xMin = (Screen.width / (isMultiplayer()?4:2)) - (Crosshair.width / 2);
        float yMin = (Screen.height / 2) - (Crosshair.height / 2);
        
        GUI.DrawTexture(new Rect(xMin, yMin, Crosshair.width, Crosshair.height), Crosshair);
        if(isMultiplayer())
            GUI.DrawTexture(new Rect(xMin + Screen.width/2.0f, yMin, Crosshair.width, Crosshair.height), Crosshair);
    }

    public void recordDeath(int addScore)
    {
        changeScore(addScore);
        noDeaths++;
        if(numberSpawned <= noDeaths)
            endWave();
    }

    private void endWave()
    {
        waveNo++;
        timer = new GenericTimer(timeBetweenWaves, false);
    }

    public void changeScore(int amount)
    {
        score += amount;
        scoreText.text = "Score: " + score;
    }

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
        Time.timeScale = 0.01f;
        endScreen.gameObject.SetActive(true);
    }

    public bool tryRevive()
    {
        if (getScore() < reviveCost) return false;
        
        changeScore(-1 * reviveCost);
        return true;
    }
}
