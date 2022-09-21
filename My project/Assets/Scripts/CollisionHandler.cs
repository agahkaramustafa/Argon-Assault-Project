using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float reloadDelay;
    [SerializeField] ParticleSystem crashParticle;
    [SerializeField] GameObject restartButton;
    [SerializeField] GameObject mainMenuButton;
    [SerializeField] GameObject timeline;

    void Update()
    {
        if (timeline.GetComponent<PlayableDirector>().state != PlayState.Playing)
        {
            GetComponent<PlayerController>().enabled = false;
            ActivateDeathCanvas();
            PauseTimeline();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        StartCrashSequence();
    }

    void StartCrashSequence()
    {
        crashParticle.Play();
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<PlayerController>().enabled = false;
        ActivateDeathCanvas();
        PauseTimeline();

    }

    void ActivateDeathCanvas()
    {
        // Activate required buttons when the player dies.
        restartButton.gameObject.SetActive(true);
        mainMenuButton.gameObject.SetActive(true);
    }

    void PauseTimeline()
    {
        // Pause timeline
        timeline.GetComponent<PlayableDirector>().playableGraph.GetRootPlayable(0).SetSpeed(0);
    }
}
