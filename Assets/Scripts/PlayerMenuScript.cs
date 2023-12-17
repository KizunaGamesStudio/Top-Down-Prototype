using System.Collections;
using System.Collections.Generic;
using Assets.HeroEditor4D.Common.Scripts.CharacterScripts;
using Assets.HeroEditor4D.Common.Scripts.Enums;
using UnityEngine;

public class PlayerMenuScript : MonoBehaviour
{
    public Character4D Character;
    // Start is called before the first frame update
    void Start()
    {
            Character.AnimationManager.SetState(CharacterState.Ready);
            Character.AnimationManager.SetState(CharacterState.Run);
                Character.SetDirection(Vector2.right);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
