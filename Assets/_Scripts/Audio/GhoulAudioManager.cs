using UnityEngine;

[RequireComponent(typeof(Animator))]
public class GhoulAudioManager : MonoBehaviour
{
    Animator animator;

    [SerializeField]
    AudioClip[] idleAudioClips;

    [SerializeField]
    AudioClip[] runAudioClips;

    [SerializeField]
    AudioClip[] attackAudioClips;


    void Awake()
    {
        animator = GetComponent<Animator>();

        animator.GetBehaviour<GhoulAudioIdleSMB>().AudioClips = idleAudioClips;
        animator.GetBehaviour<GhoulAudioRunSMB>().AudioClips = runAudioClips;
        animator.GetBehaviour<GhoulAudioAttackSMB>().AudioClips = attackAudioClips;
    }

}
