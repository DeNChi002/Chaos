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

    [SerializeField, Header("CharacterAnimation")]
    CharacterAnimation CharAnim;

    void FixedUpdate()
    {
        //上下移動の処理
        if (InputManager.Vertical > 0.0f || InputManager.Vertical < 0.0f)
        {
            if (InputManager.Vertical > 0.0f)
            {
                //右斜め上移動
                if (InputManager.Horizontal > 0.0f)
                {
                    Move(ENUMS.MOVETYPE.RIGHTUP);
                    CharAnim.MoveAnimation(ENUMS.MOVETYPE.RIGHTUP);
                }
                //左斜め上移動
                else if (InputManager.Horizontal < 0.0f)
                {
                    Move(ENUMS.MOVETYPE.LEFTUP);
                    CharAnim.MoveAnimation(ENUMS.MOVETYPE.LEFTUP);
                }
                //上移動
                else
                {
                    Move(ENUMS.MOVETYPE.UP);
                    CharAnim.MoveAnimation(ENUMS.MOVETYPE.UP);
                }
            }
            else if (InputManager.Vertical < 0.0f)
            {
                //右斜め下移動
                if (InputManager.Horizontal > 0.0f)
                {
                    Move(ENUMS.MOVETYPE.RIGHTDOWN);
                    CharAnim.MoveAnimation(ENUMS.MOVETYPE.RIGHTDOWN);
                }
                //左斜め下移動
                else if (InputManager.Horizontal < 0.0f)
                {
                    Move(ENUMS.MOVETYPE.LEFTDOWN);
                    CharAnim.MoveAnimation(ENUMS.MOVETYPE.LEFTDOWN);
                }
                //下移動
                else
                {
                    Move(ENUMS.MOVETYPE.DOWN);
                    CharAnim.MoveAnimation(ENUMS.MOVETYPE.DOWN);
                }
            }
        }
        //左右移動の処理
        else if (InputManager.Horizontal > 0.0f || InputManager.Horizontal < 0.0f)
        {
            if (InputManager.Horizontal > 0.0f)
            {
                Move(ENUMS.MOVETYPE.RIGHT);
                CharAnim.MoveAnimation(ENUMS.MOVETYPE.RIGHT);
            }
            else if (InputManager.Horizontal < 0.0f)
            {
                Move(ENUMS.MOVETYPE.LEFT);
                CharAnim.MoveAnimation(ENUMS.MOVETYPE.LEFT);
            }
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

            case ENUMS.MOVETYPE.RIGHTUP:
                Pos.x += SPEED;
                Pos.y += SPEED;               
                break;

            case ENUMS.MOVETYPE.RIGHTDOWN:
                Pos.x += SPEED;
                Pos.y -= SPEED;
                break;

            case ENUMS.MOVETYPE.LEFTUP:
                Pos.x -= SPEED;
                Pos.y += SPEED;
                break;

            case ENUMS.MOVETYPE.LEFTDOWN:
                Pos.x -= SPEED;
                Pos.y -= SPEED;
                break;
        }

        transform.position = Pos;
    }
}