using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CharacterStats))]
public class PlayerMovement : MonoBehaviour
{
    Rigidbody rigidbody ;
    CharacterStats stats;
    InputAction.CallbackContext context;

    int moveSpeed;
    Vector2 dir;

    AnimationReceiver anim;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        stats = GetComponent<CharacterStats>();
        moveSpeed = stats.Speed /10;

        anim = GetComponent<AnimationReceiver>();
      
    }

    // Update is called once per frame
    void FixedUpdate()
    {

       rigidbody.velocity = new Vector3(moveSpeed * dir.x, rigidbody.velocity.y, moveSpeed * dir.y);
        
        anim.SetFloat("moveSpeed", rigidbody.velocity.sqrMagnitude);
    }

    public void setVelocity(InputAction.CallbackContext inputs)
    {
        dir = inputs.ReadValue<Vector2>();
        if (dir.x > 0)
            transform.rotation = Quaternion.Euler(Vector3.up * 90);
        else if (dir.x < 0)
            transform.rotation = Quaternion.Euler(Vector3.down * 90);
       
        context = inputs;
    }
    private void OnEnable()
    {
        dir = context.ReadValue<Vector2>();
    }

    private void OnDisable()
    {
        dir = Vector2.zero;
    }
    void PlayAnimation(string id, float val)
    {

    }

}
