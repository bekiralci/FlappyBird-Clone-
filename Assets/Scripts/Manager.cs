using UnityEngine;

public class Manager : MonoBehaviour
{
    [SerializeField] Bird bird;

    [SerializeField] GameObject playPanel;
    [SerializeField] GameObject playingPanel;
    [SerializeField] GameObject gameOverpanel;

    public enum State
    {
        WaitingToStart,
        Playing,
        GameOver,
    }

    public State state;

    void Start()
    {
        state = State.WaitingToStart;
    }

    void Update()
    {
        StateControl();
    }   
    public void Play()
    {
        state = State.Playing;
    }

    public void Restart()
    {
        state = State.Playing;
    }
    
    private void StateControl()
    {
        switch (state)
        {
            case State.WaitingToStart:
                playPanel.SetActive(true);
                playingPanel.SetActive(false);
                gameOverpanel.SetActive(false);
                break;
            case State.Playing:
                playPanel.SetActive(false);
                playingPanel.SetActive(true);
                gameOverpanel.SetActive(false);
                Time.timeScale = 1.0f;
                break;
            case State.GameOver:
                playPanel.SetActive(false);
                playingPanel.SetActive(false);
                gameOverpanel.SetActive(true);
                Time.timeScale = 0f;
                break;
        }
    }
    
}
