using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    FiniteStateMachine<SoundController> soundSM;
    public AudioSource bgmSrc;
    public AudioSource sfxSrc;
    public AudioSource mushSrc;

    public AudioClip growing;
    public AudioClip connecting;

    public int gameState = 0;

    public AudioClip[] bgmClips;
    public AudioClip[] mushClips;

    [SerializeField] bool _isTesting = false;

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

        if (_isTesting)
        {
            if (Input.GetKeyUp(KeyCode.Space))
            {
                NextAudioState();
            }

        }

    }

    public void NextAudioState()
    {
        if (gameState != 4)
        {
            gameState++;
        }
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

    public void PlayMushSound(int mushClip, float delay)
    {
        mushSrc.clip = mushClips[mushClip];
        mushSrc.PlayDelayed(delay);
        //mushSrc.PlayOneShot(mushClips[mushClip]);
    }

    private class State0 : FiniteStateMachine<SoundController>.State //Intro State
    {
        public override void OnEnter()
        {
            //Sad Note one shot
            Context.PlayMushSound(0, 0f);
        }

        public override void Update()
        {
            if (Context.gameState != 0)
            {
                TransitionTo<State1>(); //Intro to Root1

            }
        }
        public override void OnExit()
        {
            Context.mushSrc.Stop();
        }
    }

    private class State1 : FiniteStateMachine<SoundController>.State //Root 1 State
    {
        public override void OnEnter()
        {
            //Search Music on Loop
            Context.bgmSrc.clip = Context.bgmClips[0];
            Context.bgmSrc.Play();
        }

        public override void Update()
        {
            if (Context.gameState != 1)
            {
                TransitionTo<State2>(); //Root 1 to Connect 1
            }
        }
        public override void OnExit()
        {
            Context.bgmSrc.Stop();
        }
    }

    private class State2 : FiniteStateMachine<SoundController>.State //Connect 1 State
    {
        public override void OnEnter()
        {
            //Play Connect one shot
            Context.PlayConnectingSound();
            //Play happy note one shot on delay
            Context.PlayMushSound(1, 3f);
        }

        public override void Update()
        {
            if (Context.gameState != 2)
            {
                TransitionTo<State3>(); //Connect 1 to Root 2

            }
        }

        public override void OnExit()
        {
            Context.mushSrc.Stop();
        }
    }
    private class State3 : FiniteStateMachine<SoundController>.State //Root 2 State
    {
        public override void OnEnter()
        {
            //Craving Music on Loop
            Context.bgmSrc.clip = Context.bgmClips[1];
            Context.bgmSrc.Play();
        }

        public override void Update()
        {
            if (Context.gameState != 3)
            {
                TransitionTo<State4>(); //Root 2 to Connect 2

            }
        }

        public override void OnExit()
        {
            Context.bgmSrc.Stop();
        }
    }

    private class State4 : FiniteStateMachine<SoundController>.State //Connect 2 State
    {
        public override void OnEnter()
        {
            //Play Connect one shot
            Context.PlayConnectingSound();
            //Play harmony note one shot
            Context.PlayMushSound(2, 3);
            //Play Mosaic Music on Loop on delay
            Context.bgmSrc.clip = Context.bgmClips[2];
            Context.bgmSrc.PlayDelayed(7f);
        }

        public override void OnExit()
        {
            Context.bgmSrc.Stop();
            Context.mushSrc.Stop();
        }
    }
}
