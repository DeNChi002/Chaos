using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// キャラクターの移動制御
/// </summary>
public class CharacterMove : MonoBehaviour
{
    [SerializeField, Header("移動速度"), Range(0.1f, 1.0f)]
    float SPEED;

    void FixedUpdate()
    {
        //上移動
        if (InputManager.Vertical > 0.0f)
        {
            Move(ENUMS.MOVETYPE.UP);
        }
        //下移動
        else if (InputManager.Vertical < 0.0f)
        {
            Move(ENUMS.MOVETYPE.DOWN);
        }
        //右移動
        else if (InputManager.Horizontal > 0.0f)
        {
            Move(ENUMS.MOVETYPE.RIGHT);
        }
        //左移動
        else if (InputManager.Horizontal < 0.0f)
        {
            Move(ENUMS.MOVETYPE.LEFT);
        }
    }

    public void Move(ENUMS.MOVETYPE _type)
    {
        Vector3 Pos = transform.position;

        switch (_type)
        {
            case ENUMS.MOVETYPE.UP:
                Pos.y += SPEED;
                break;

            case ENUMS.MOVETYPE.DOWN:
                Pos.y -= SPEED;
                break;

            case ENUMS.MOVETYPE.RIGHT:
                Pos.x += SPEED;
                break;

            case ENUMS.MOVETYPE.LEFT:
                Pos.x -= SPEED;
                break;
        }

        transform.position = Pos;
    }
}