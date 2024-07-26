using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text teamAScoreText;
    public Text teamBScoreText;
    public Text winText;
    public Image teamAFrame;
    public Image teamBFrame;
    public AudioSource audioSource;
    public AudioClip winClip;
    public AudioClip loseClip;

    private int teamAPower = 0;
    private int teamBPower = 0;
    private bool gameOver = false;

    void Start()
    {
        // Initialize scores and frames
        UpdateScore();
        winText.gameObject.SetActive(false);
        teamAFrame.enabled = false;
        teamBFrame.enabled = false;
        PlayBackgroundMusic();
    }

    void Update()
    {
        if (!gameOver)
        {
            // Check if one team has won
            if (teamAPower >= 100)
            {
                EndGame("Team A Wins!", winClip);
            }
            else if (teamBPower >= 100)
            {
                EndGame("Team B Wins!", winClip);
            }
        }
    }

    public void AddPowerToTeamA(int power)
    {
        teamAPower += power;
        UpdateScore();
    }

    public void AddPowerToTeamB(int power)
    {
        teamBPower += power;
        UpdateScore();
    }

    void UpdateScore()
    {
        teamAScoreText.text = "Team A: " + teamAPower;
        teamBScoreText.text = "Team B: " + teamBPower;
    }

    void EndGame(string message, AudioClip clip)
    {
        gameOver = true;
        winText.text = message;
        winText.gameObject.SetActive(true);
        audioSource.PlayOneShot(clip);
        // Show top contributors
    }

    void PlayBackgroundMusic()
    {
        // Implement background music logic
        audioSource.loop = true;
        audioSource.Play();
    }
}
