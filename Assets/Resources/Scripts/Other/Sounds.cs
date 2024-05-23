using UnityEngine;
using UnityEngine.Serialization;

public class Sounds : MonoBehaviour
{
    [FormerlySerializedAs("beeSounds")] public AudioClip[] BeeSounds;
    [FormerlySerializedAs("enemyAttackSounds")] public AudioClip[] EnemyAttackSounds;
    [FormerlySerializedAs("losingSounds")] public AudioClip[] LosingSounds;
    [FormerlySerializedAs("losingFlowerSounds")] public AudioClip[] LosingFlowerSounds;
    [FormerlySerializedAs("losingPlantSounds")] public AudioClip[] LosingPlantSounds;
    [FormerlySerializedAs("placingSounds")] public AudioClip[] PlacingSounds;
    public AudioClip StartButtonSound;
    public AudioClip WinSound;

    public AudioClip[] SelectingSounds;     // button
    public AudioClip[] CantAffordSounds;    //button
   

    private AudioSource audioSource;

    private void Awake()
    {
        // sound plays one time
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null) //check for AudioSource component (debug)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    public void PlaySelectingSound()
    {
        audioSource.PlayOneShot(SelectingSounds[Random.Range(0, SelectingSounds.Length)], 1f);
    }
    public void PlayCantAffordSound()
    {
        audioSource.PlayOneShot(CantAffordSounds[Random.Range(0, CantAffordSounds.Length)], 1f);
    }
    public void PlayBeeSound()
    {
        audioSource.PlayOneShot(BeeSounds[Random.Range(0, BeeSounds.Length)], 1f);
    }

    public void PlayEnemyAttackSound()
    {
        audioSource.PlayOneShot(EnemyAttackSounds[Random.Range(0, EnemyAttackSounds.Length)], 1f);
    }

    public void PlayLosingSound()
    {
        audioSource.Stop();
        audioSource.PlayOneShot(LosingSounds[Random.Range(0, LosingSounds.Length)], 0.7f);
    }

    public void PlayLosingFlowerSound()
    {
        audioSource.PlayOneShot(LosingFlowerSounds[Random.Range(0, LosingFlowerSounds.Length)], 1f);
    }

    public void PlayLosingPlantSound()
    {
        audioSource.PlayOneShot(LosingPlantSounds[Random.Range(0, LosingPlantSounds.Length)], 0.6f);
    }

    public void PlayPlacingSound()
    {
        // audioSource.PlayOneShot(PlacingSounds[Random.Range(0, PlacingSounds.Length)], 0.5f); turned off since it was annoying
    }

    public void PlayStartButtonPressSound()
    {
        audioSource.PlayOneShot(StartButtonSound, 1f);
    }

    public void PlayVictorySound()
    {
        audioSource.Stop();
        audioSource.PlayOneShot(WinSound, 1f);
    }

  
}

