using UnityEngine;

public class RandomVoiceLines : MonoBehaviour
{
    private Animator animator;

    // Array of audio clips to hold the voice lines
    public AudioClip[] voiceLines;

    // Audio source to play the clips
    private AudioSource audioSource;

    // Minimum and maximum time between voice lines
    public float minInterval = 5f;  // Minimum interval between voice lines
    public float maxInterval = 15f; // Maximum interval between voice lines
    private float countdown;

    private void Start()
    {
        animator = GetComponent<Animator>();

        // Get the AudioSource component
        audioSource = GetComponent<AudioSource>();

        // Start the process of playing random voice lines
        countdown = Random.Range(minInterval, maxInterval);
    }

    void Update()
    {
        countdown -= Time.deltaTime;

        if (countdown <=0f)
        {
        
            animator.SetTrigger("PlayAnimationTrigger");

            int randomIndex = Random.Range(0, voiceLines.Length);
            AudioClip randomVoiceLine = voiceLines[randomIndex];

            // Play the random voice line
            audioSource.PlayOneShot(randomVoiceLine);

            countdown = Random.Range(minInterval, maxInterval);
        }
    }
}