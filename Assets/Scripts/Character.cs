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

    public float RotationSpeed { get; set; }

    [SerializeField] private Weapon weapon;
    [SerializeField] private float speed = 2f;
    [SerializeField] private AnimationCurve routeCurve;
    [SerializeField] private Transform characterCraphics;
    [SerializeField] private float startY = -3.75f;
    [SerializeField] private float speedJump = 1f;

    private float _iteration = 0f;
    private float changeStateTimer = 0f;

    public static Action OnStartWaiting;

    private void Awake() 
    {
        stateMachine = new StateMachine();

        waitingState = new Waiting(stateMachine, this);
        runningState = new Running(stateMachine, this);
        shootingState = new Shooting(stateMachine, this);
        deathState = new Death(stateMachine, this);
        OnStartWaiting += StartWaiting;
        StartWaiting();
    }

    private void OnDisable()
    {
        OnStartWaiting -= StartWaiting;
    }

    private void Update() 
    {
        stateMachine.CurrnetState.InputLogic();
        stateMachine.CurrnetState.LogicUpdate();
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
        characterCraphics.Rotate(new Vector3(0f, 0f, RotationSpeed) * Time.fixedDeltaTime);
        if(Time.time - changeStateTimer > 3f)
        {
            characterCraphics.Rotate(Vector3.zero);
            stateMachine.ChangeState(runningState);
            changeStateTimer = 0f;
        }
    }

    

    public IEnumerator ChangeState()
    {
        yield return new WaitForSeconds(changeStateTimer);
        stateMachine.ChangeState(shootingState);
        changeStateTimer = Time.time;
        Time.timeScale = 0.5f;
    }

    public void CharacterShoot()
    {
        weapon.Shoot();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.TryGetComponent<RotationTrigger>(out RotationTrigger rot))
        {
            RotationSpeed = rot.RotationSpeedData.rotationSpeed;
            StartCoroutine(ChangeState());
            other.gameObject.SetActive(false);
        }
    }

    public void SetIteration(float iteration)
    {
        _iteration = iteration;
    }

    private void StartWaiting()
    {
        stateMachine.Initialize(waitingState);
    }
}