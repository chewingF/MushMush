using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    FiniteStateMachine<SoundController> soundSM;
    public AudioSource bgmSrc;
    public AudioSource sfxSrc;

    public AudioClip growing;
    public AudioClip connecting;

    public int gameState = 0;

    public AudioClip[] bgmClips;

    // Start is called before the first frame update
    void Start()
    {
        soundSM = new FiniteStateMachine<SoundController>(this);
        soundSM.TransitionTo<State0>();
    }

    // Update is called once per frame
    void Update()
    {
        soundSM.Update();
    }

    public void PlayGrowingSound()
    {
        if (sfxSrc.isPlaying == false)
            sfxSrc.PlayOneShot(growing);
    }

    public void PlayConnectingSound() 
    {
        sfxSrc.PlayOneShot(connecting);
    }

    private class State0 : FiniteStateMachine<SoundController>.State
    {
        public override void OnEnter()
        {
            Context.bgmSrc.clip = Context.bgmClips[Context.gameState];
        }

        public override void Update()
        {
            //logic to see if your game state is still 0/state1 
            //TransitionTo<State1>();
        }

        public override void OnExit()
        {
        }
    }

    private class State1 : FiniteStateMachine<SoundController>.State
    {
        public override void OnEnter()
        {
            Context.bgmSrc.clip = Context.bgmClips[1];
        }

        public override void Update()
        {
            //logic to see if your game state is still 0/state1 
            //TransitionTo<State3>();
        }

        public override void OnExit()
        {
        }
    }
}
