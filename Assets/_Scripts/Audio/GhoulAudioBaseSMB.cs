using UnityEngine;

public class GhoulAudioBaseSMB : StateMachineBehaviour
{
    public AudioClip[] AudioClips { get; set; }

    protected AudioSource audioSource;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        audioSource = animator.GetComponent<AudioSource>();
    }

    protected void PlayRandomAudioClip()
    {
        if (AudioClips != null && AudioClips.Length > 0 && audioSource != null)
        {
            int randomIndex = Random.Range(0, AudioClips.Length);
            AudioClip randomClip = AudioClips[randomIndex];
            audioSource.clip = randomClip;
            audioSource.Play();
        }
    }
}
