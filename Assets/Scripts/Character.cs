using System.Collections;
using UnityEngine;

public class Character : MonoBehaviour 
{
    private StateMachine stateMachine;
    public Waiting waitingState;
    public Running runningState;
    public Shooting shootingState;
    public Death deathState;

    [SerializeField] private float speed = 2f;
    [SerializeField] private AnimationCurve routeCurve;
    [SerializeField] private Transform characterCraphics;
    [SerializeField] private float startY = -3.75f;
    [SerializeField] private float jumpHeight = 1f;
    [SerializeField] private float speedJump = 1f;
    private float _iteration = 0f;

    private float changeStateTimer = 0f;

    private void Awake() 
    {
        stateMachine = new StateMachine();

        waitingState = new Waiting(stateMachine, this);
        runningState = new Running(stateMachine, this);
        shootingState = new Shooting(stateMachine, this);
        deathState = new Death(stateMachine, this);

        stateMachine.Initialize(waitingState);
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
        characterCraphics.Rotate(new Vector3(0f, 0f, 120f) * Time.fixedDeltaTime);
        if(Time.time - changeStateTimer > 3f)
        {
            characterCraphics.Rotate(Vector3.zero);
            stateMachine.ChangeState(runningState);
        }
    }

    

    public IEnumerator ChangeState()
    {
        yield return new WaitForSeconds(changeStateTimer);
        stateMachine.ChangeState(shootingState);
        changeStateTimer = Time.time;
        //Time.timeScale = 0.5f;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.TryGetComponent<RotationTrigger>(out RotationTrigger rot))
        {
            Debug.Log("yep");
            StartCoroutine(ChangeState());
        }
    }
}