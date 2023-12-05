using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D _rb;
    private float _speed;
    [SerializeField] private float _walkSpeed;
    [SerializeField] private float _runSpeed;
    [SerializeField] private float _rollSpeed;
    private Vector2 _direction;
    private bool _isRunning;
    private bool _isRolling;


    #region Getters&Setters
    public Vector2 direction { 
        get{ return _direction;} 
        private set{_direction = value;}
    }

    public float speed { 
        get{ return _speed;} 
        private set{_speed = value;}
    }
    
    public bool isRolling { 
        get{ return _isRolling;} 
        private set{_isRolling = value;}
    }
    #endregion


    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _speed = _walkSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        InputMovement();
        OnRun();
        OnRolling();
    }

    private void FixedUpdate() {
        OnMove();
    }

    #region MOVEMENT
    private void InputMovement(){
        _direction =  new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }
    private void OnMove(){
        _rb.MovePosition(_rb.position + _direction * _speed * Time.fixedDeltaTime);
    }

    private void OnRun(){
        if(Input.GetKeyDown(KeyCode.LeftShift) && !_isRolling){
            _speed = _runSpeed;
            _isRunning = true;
        }
        if(Input.GetKeyUp(KeyCode.LeftShift) && !_isRolling){
            _speed = _walkSpeed;
            _isRunning = false;
        }
    }

    private void OnRolling(){
        if(Input.GetKeyDown(KeyCode.Space) && _isRunning){
            _isRolling = true;
            StartCoroutine(EndRoll(_speed));
        }
    }

    IEnumerator EndRoll(float speed){
        _speed = _rollSpeed;
        yield return new WaitForSeconds(0.6f);
        _speed = speed;
        _isRolling = false;
    }

    #endregion
}
