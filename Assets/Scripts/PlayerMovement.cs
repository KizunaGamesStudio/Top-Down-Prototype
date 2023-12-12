using System.Linq;
using Assets.HeroEditor4D.Common.Scripts.CharacterScripts;
using Assets.HeroEditor4D.Common.Scripts.Enums;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public Character4D Character;
    public bool InitDirection;
    public int MovementSpeed;

    private bool _moving;
        Vector2 rotationDirection;

    public void Start()
    {
        Character.AnimationManager.SetState(CharacterState.Idle);

        if (InitDirection)
        {
            Character.SetDirection(Vector2.up);
        }
    }

    public void Update()
    {
        //SetDirection();
        Move();
        //ChangeState();
        //Actions();
        RotatePlayer();

        if (Input.GetKeyDown(KeyCode.R))
        {
                Character.AnimationManager.SetState(CharacterState.Run);
        }
    }

    private void SetDirection()
    {
        Vector2 direction;

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            direction = Vector2.left;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) ||  Input.GetKey(KeyCode.D))
        {
            direction = Vector2.right;
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow) ||  Input.GetKey(KeyCode.W))
        {
            direction = Vector2.up;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) ||  Input.GetKey(KeyCode.S))
        {
            direction = Vector2.down;
        }
        else return;

        Character.SetDirection(direction);
    }

    void RotatePlayer(){
        var playerScreenPoint = Camera.main.WorldToScreenPoint(transform.position);
        Debug.Log(Input.mousePosition.x - playerScreenPoint.x);

        if(Input.mousePosition.x < playerScreenPoint.x) {
            rotationDirection = Vector2.left;
        } else if(Input.mousePosition.x > playerScreenPoint.x) {
            rotationDirection = Vector2.right;
        }

        if(Input.mousePosition.y < playerScreenPoint.y && ((Input.mousePosition.x - playerScreenPoint.x) > -45 && (Input.mousePosition.x - playerScreenPoint.x) < 45)){
            rotationDirection = Vector2.down;
        }else if(Input.mousePosition.y > playerScreenPoint.y && ((Input.mousePosition.x - playerScreenPoint.x) > -60 && (Input.mousePosition.x - playerScreenPoint.x) < 60)){
            rotationDirection = Vector2.up;
        }
        
        Character.SetDirection(rotationDirection);
    }

    private void Move()
    {
        if (MovementSpeed == 0) return;

        var direction = Vector2.zero;

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            direction += Vector2.left;
        }

        else if (Input.GetKeyDown(KeyCode.RightArrow) ||  Input.GetKey(KeyCode.D))
        {
            direction += Vector2.right;
        }

        if (Input.GetKey(KeyCode.UpArrow) ||  Input.GetKey(KeyCode.W))
        {
            direction += Vector2.up;
        }

        if (Input.GetKey(KeyCode.DownArrow) ||  Input.GetKey(KeyCode.S))
        {
            direction += Vector2.down;
        }

        if (direction == Vector2.zero)
        {
            if (_moving)
            {
                Character.AnimationManager.SetState(CharacterState.Idle);
                _moving = false;
            }
        }
        else
        {
            Character.AnimationManager.SetState(CharacterState.Run);
            Character.transform.position += (Vector3) direction.normalized * MovementSpeed * Time.deltaTime;
            _moving = true;
        }
    }

}
