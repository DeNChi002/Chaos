using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GamepadInput;

/// <summary>
/// コントローラー入力検知
/// </summary>
public class InputManager : MonoBehaviour
{
    //Axis用インプット変数
    public static float Horizontal, Vertical;

    //Button用インプット変数
    public static bool btn_Square, btn_Cross, btn_Circle, btn_Triangle, btn_Start;

    //プレイヤーの操作
    void Update()
    {
        //if (DATABASE.PlayIsGamePad)
        //{
        //    for (int i = 0; i < (int)DATABASE.PLAYER_NUM + 1; i++)
        //    {
        //        //GamePadDebugWindow((GamePad.Index)i);             
        //    }
        //}
        //else
        //{
            
        //}

        KeyInput();
    }

    /// <summary>
    /// キー入力
    /// </summary>
    private void KeyInput()
    {
        //移動
        Horizontal = Input.GetAxisRaw("Horizontal");
        Vertical = Input.GetAxisRaw("Vertical");

        btn_Square = Input.GetButtonDown("Fire1");

        btn_Triangle = Input.GetButtonDown("Jump");

        //KeyDebugWindow();
    }

    /// <summary>
    /// ゲームパッド入力のデバッグ
    /// </summary>
    private void GamePadDebugWindow(GamePad.Index controller)
    {
        //ゲームパッド(プレイヤー)を取得
        GamepadState state = GamePad.GetState(controller);

        //Button
        Debug.Log("Gamepad " + controller);
        Debug.Log("[" + controller + "：P]" + "Ａ：" + state.A);
        Debug.Log("[" + controller + "：P]" + "Ｂ：" + state.B);
        Debug.Log("[" + controller + "：P]" + "Ｘ：" + state.X);
        Debug.Log("[" + controller + "：P]" + "Ｙ：" + state.Y);
        Debug.Log("[" + controller + "：P]" + "START：" + state.Start);
        Debug.Log("[" + controller + "：P]" + "Back：" + state.Back);
        Debug.Log("[" + controller + "：P]" + "L1：" + state.LeftShoulder);
        Debug.Log("[" + controller + "：P]" + "R1：" + state.RightShoulder);
        Debug.Log("[" + controller + "：P]" + "POV_Left：" + state.Left);
        Debug.Log("[" + controller + "：P]" + "POV_Rigt：" + state.Right);
        Debug.Log("[" + controller + "：P]" + "POV_Up：" + state.Up);
        Debug.Log("[" + controller + "：P]" + "POV_Down：" + state.Down);
        Debug.Log("[" + controller + "：P]" + "L3：" + state.LeftStick);
        Debug.Log("[" + controller + "：P]" + "R3：" + state.RightStick);

        Debug.Log("-----------------------------");

        //Trigger
        Debug.Log("[" + controller + "：P]" + "L2：" + System.Math.Round(state.LeftTrigger, 2));
        Debug.Log("[" + controller + "：P]" + "R2：" + System.Math.Round(state.RightTrigger, 2));

        Debug.Log("-----------------------------");

        //Axis
        Debug.Log("[" + controller + "：P]" + "LStick：" + state.LeftStickAxis);
        Debug.Log("[" + controller + "：P]" + "RStick：" + state.rightStickAxis);
        Debug.Log("[" + controller + "：P]" + "DPad：" + state.dPadAxis);
    }

    //キー入力のデバッグログを出力するメソッド
    void KeyDebugWindow()
    {
        #region 右スティック、十字キーのデバッグ
        if (Horizontal > 0.0f)
        {
            Debug.Log("Right");
        }
        else if (Horizontal < 0.0f)
        {
            Debug.Log("Left");
        }
        if (Vertical > 0.0f)
        {
            Debug.Log("Up");
        }
        else if (Vertical < 0.0f)
        {
            Debug.Log("Down");
        }
        #endregion

        //ボタン用のデバッグ処理
        if (btn_Square) Debug.Log("アイテム切り替え");

        if (btn_Cross) Debug.Log("キャラ切り替え");

        if (btn_Circle) Debug.Log("物を持つ");

        if (btn_Triangle) Debug.Log("追従命令");

        if (btn_Start) Debug.Log("START");

    }
}