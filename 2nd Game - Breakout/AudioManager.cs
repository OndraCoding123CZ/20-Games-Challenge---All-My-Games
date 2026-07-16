using UnityEngine;

public class AudioManager : MonoBehaviour
{

    AudioSource gameOverSound;
    AudioSource gameCompletedSound;

    [SerializeField] BallMovementScript ballMovementScript;

    void Start()
    {

        gameOverSound = GetComponent<AudioSource>();
        gameCompletedSound = GetComponent<AudioSource>();
        
    }

    void Update()
    {

        PlayGameOverSound();
        PlayGameCompletedSound();

    }

    void PlayGameOverSound()
    {

        if (!gameOverSound.isPlaying)
        {

            if (ballMovementScript.livesCounter == 0)
            {

                gameOverSound.Play();

            }
        }
    }

    void PlayGameCompletedSound()
    {

        if (!gameCompletedSound.isPlaying)
        {

            if (ballMovementScript.score == 240)
            {

                gameCompletedSound.Play();

            }
        }
    }
}
