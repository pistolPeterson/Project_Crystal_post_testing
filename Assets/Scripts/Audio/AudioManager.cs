using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
   public static AudioManager Instance;
   private void Awake(){
   if (Instance != null){
    Debug.LogError("More than one audio manager in scene");
    Destroy(this.gameObject);
    return;
   } Instance = this;

   }
   private IEnumerator FadeAudio(AudioSource activeSource, float transitionTime, float targetVolume){
    float currentVolume = activeSource.volume;
    for (float T = 0.0f; T <= transitionTime; T += Time.deltaTime){
        activeSource.volume = Mathf.Lerp(currentVolume, targetVolume, T / transitionTime);
        yield return null;
    } 
    activeSource.volume = targetVolume;
   }
   public void FadeAudioToVolume (AudioSource activeSource, float transitionTime, float targetVolume){
    StartCoroutine(FadeAudio(activeSource,transitionTime,targetVolume));
    
   }

    public void PlayAudioOneShot(AudioSource source, AudioClip clip)
    {
        source.PlayOneShot(clip);
    }
     public void PlayAudioOneShot(AudioSource source, AudioClip clip, bool isRandomVol)
    {
        if (isRandomVol == true)
        {
            RandomVolume(source);
        }
        source.PlayOneShot(clip);
    }
    private void RandomVolume(AudioSource source)
    {
        float randomVolume = Random.Range(0.8f, 1.0f); 
        source.volume = randomVolume;
    }

}   
