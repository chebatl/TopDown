using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private Player _player;
    private Animator _animator;
    [SerializeField] private float limitWalkToRun;
    // Start is called before the first frame update
    void Start()
    {
        _player = GetComponent<Player>();
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(_player.direction.sqrMagnitude > 0){
            if(_player.isRolling){
            _animator.SetInteger("Transition",3);
            }else{
                if(_player.speed > limitWalkToRun){
                    _animator.SetInteger("Transition",2);
                }else{
                    _animator.SetInteger("Transition",1);
                }
            }
        }else{
            _animator.SetInteger("Transition",0);
        }

        if(_player.direction.x > 0 ){
            transform.eulerAngles = new Vector2(0,0);
        }
        
        if(_player.direction.x < 0 ){
            transform.eulerAngles = new Vector2(0,180);
        }

        
    }
}
