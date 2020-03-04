using System;
using System.Collections;
using UnityEngine;

public class Character : MonoBehaviour 
{
    private StateMachine stateMachine;
    public Waiting waitingState;
    public Running runningState;
    public Shooting shootingState;
    public Death deathState;
    public ResultPanelState resultPanelState;

    public float RotationSpeed { get; set; }

    [SerializeField] private Animator animatorCharacter;
    [SerializeField] private Weapon weapon;
    [SerializeField] private float speed = 2f;
    [SerializeField] private AnimationCurve routeCurve;
    [SerializeField] private Transform characterCraphics;
    [SerializeField] private float startY = -3.75f;
    [SerializeField] private float speedJump = 1f;
    
    private float _iteration = 0f;
    private float changeStateTimer = 0f;

    public Health health;
    public static Action OnStartWaiting;
    public static Action OnDeath;

    private void Awake() 
    {
        stateMachine = new StateMachine();
        var camera = Camera.main.GetComponent<CameraFollower>();
        waitingState = new Waiting(stateMachine, this, animatorCharacter);
        runningState = new Running(stateMachine, this, camera, animatorCharacter);
        shootingState = new Shooting(stateMachine, this, camera, animatorCharacter);
        deathState = new Death(stateMachine, this);
        resultPanelState = new ResultPanelState(stateMachine, this);
        health = GetComponent<Health>();
        stateMachine.Initialize(waitingState);
        StartWaiting();
    }

    private void OnEnable()
    {
        OnStartWaiting += StartWaiting;
        FinalReached.OnFinalPanelShowed += SetResultPanelState;
        Time.timeScale = 1f;
        StartWaiting(); 
    }

    private void OnDisable()
    {
        OnStartWaiting -= StartWaiting;
        FinalReached.OnFinalPanelShowed -= SetResultPanelState;
    }

    private void Update() 
    {
        stateMachine.CurrnetState.InputLogic();;

        if(health.health <= 0)
        {
            stateMachine.ChangeState(deathState);
            OnDeath?.Invoke();
            Time.timeScale = 1f;
        }
    }

    private void FixedUpdate() 
    {
        stateMachine.CurrnetState.PhysicsUpdate();
    }

    public void Movement()
    {
        transform.Translate(Vector3.right * speed * Time.fixedDeltaTime);

        var pos = transform.position;

        pos.y = startY + routeCurve.Evaluate(_iteration);

        transform.position = pos;
        _iteration += Time.fixedDeltaTime * speedJump;

        if (_iteration < 30f) return;
        _iteration = 0f;
    }

    public void RotateCharacter()
    {
        characterCraphics.Rotate(new Vector3(RotationSpeed, 0f, 0f) * Time.fixedDeltaTime);
        if(Time.time > changeStateTimer)
        {
            characterCraphics.Rotate(Vector3.zero);
            stateMachine.ChangeState(runningState);
            changeStateTimer = 0f;
            RotationSpeed = 0f;
        }
    }

    public IEnumerator ChangeState(float time, State state)
    {
        yield return new WaitForSeconds(time);
        stateMachine.ChangeState(state);
        changeStateTimer = Time.time + 3f;
    }

    public void CharacterShoot()
    {
        weapon.Shoot();
    }

    private void OnTriggerEnter(Collider other)
    {
        var rot = other.gameObject.GetComponent<RotationTrigger>();
        if(rot)
        {
            RotationSpeed = rot.RotationSpeedData.rotationSpeed;
            StartCoroutine(ChangeState(0f, shootingState));
            other.gameObject.SetActive(false);
        }
    }

    public void SetIteration(float iteration)
    {
        _iteration = iteration;
    }

    private void StartWaiting()
    {
        characterCraphics.rotation = Quaternion.Euler(new Vector3(0f, 90f, 0f));
        stateMachine.ChangeState(waitingState);
    }

    private void SetResultPanelState()
    {
        stateMachine.ChangeState(resultPanelState);
    }
}