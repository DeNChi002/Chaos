using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// キャラクターのアニメーション制御
/// </summary>
public class CharacterAnimation : MonoBehaviourExtension
{
    [SerializeField, Header("上移動のアニメーション")]
    [Header("[0]：待機　[1]：右足上げ　[2]：左足上げ")]
    Sprite[] UpAnims;

    [SerializeField, Header("下移動のアニメーション")]
    [Header("[0]：待機　[1]：右足上げ　[2]：左足上げ")]
    Sprite[] DownAnims;

    [SerializeField, Header("右移動のアニメーション")]
    [Header("[0]：待機　[1]：右足上げ　[2]：左足上げ")]
    Sprite[] RightAnims;

    [SerializeField, Header("左移動のアニメーション")]
    [Header("[0]：待機　[1]：右足上げ　[2]：左足上げ")]
    Sprite[] LeftAnims;

    [SerializeField, Header("右斜め上移動のアニメーション")]
    [Header("[0]：待機　[1]：右足上げ　[2]：左足上げ")]
    Sprite[] RightUpTiltAnims;

    [SerializeField, Header("左斜め上移動のアニメーション")]
    [Header("[0]：待機　[1]：右足上げ　[2]：左足上げ")]
    Sprite[] LeftUpTiltAnims;

    [SerializeField, Header("右斜め下移動のアニメーション")]
    [Header("[0]：待機　[1]：右足上げ　[2]：左足上げ")]
    Sprite[] RightDownTiltAnims;

    [SerializeField, Header("左斜め下移動のアニメーション")]
    [Header("[0]：待機　[1]：右足上げ　[2]：左足上げ")]
    Sprite[] LeftDownTiltAnims;

    SpriteRenderer Renderer;

    //現在のアニメーション番号
    int AnimNum = 0;

    //歩行状態判定値
    bool MovingFlg = false;

    //方向判定値
    ENUMS.MOVETYPE SaveType;  

    void Start ()
    {
        //初期画像を設定
        Renderer = GetComponent<SpriteRenderer>();
        Renderer.sprite = DownAnims[0];

        SaveType = ENUMS.MOVETYPE.DOWN;
	}
	
	void Update ()
    {
        //上下移動の処理
        if(InputManager.Vertical > 0.0f || InputManager.Vertical < 0.0f)
        {
            if(InputManager.Vertical > 0.0f)
            {
                //右斜め上移動
                if (InputManager.Horizontal > 0.0f)
                {
                    MoveAnimation(ENUMS.MOVETYPE.RIGHTUP);
                }
                //左斜め上移動
                else if (InputManager.Horizontal < 0.0f)
                {
                    MoveAnimation(ENUMS.MOVETYPE.LEFTUP);
                }
                //上移動
                else
                {
                    MoveAnimation(ENUMS.MOVETYPE.UP);
                }
            }
            else if(InputManager.Vertical < 0.0f)
            {
                //右斜め下移動
                if (InputManager.Horizontal > 0.0f)
                {
                    MoveAnimation(ENUMS.MOVETYPE.RIGHTDOWN);
                }
                //左斜め下移動
                else if (InputManager.Horizontal < 0.0f)
                {
                    MoveAnimation(ENUMS.MOVETYPE.LEFTDOWN);
                }
                //下移動
                else
                {
                    MoveAnimation(ENUMS.MOVETYPE.DOWN);
                }
            }          
        }
        //左右移動の処理
        else if(InputManager.Horizontal > 0.0f || InputManager.Horizontal < 0.0f)
        {
            if(InputManager.Horizontal > 0.0f)
            {
                MoveAnimation(ENUMS.MOVETYPE.RIGHT);
            }
            else if(InputManager.Horizontal < 0.0f)
            {
                MoveAnimation(ENUMS.MOVETYPE.LEFT);
            }
        }       
    }

    /// <summary>
    /// 移動のアニメーションを管理するメソッド
    /// </summary>
    public void MoveAnimation(ENUMS.MOVETYPE _type)
    {
        //方向入力が変化した場合
        if(SaveType != _type)
        {
            //アニメーション番号をリセットする
            AnimNum = 0;

            SaveType = _type;

            Debug.Log("方向変更");
        }

        if (!MovingFlg)
        {
            MovingFlg = true;

            AnimNum++;

            switch (_type)
            {
                case ENUMS.MOVETYPE.UP:
                    SetAnimSprites(UpAnims);
                    break;

                case ENUMS.MOVETYPE.DOWN:
                    SetAnimSprites(DownAnims);
                    break;

                case ENUMS.MOVETYPE.RIGHT:
                    SetAnimSprites(RightAnims);
                    break;

                case ENUMS.MOVETYPE.LEFT:
                    SetAnimSprites(LeftAnims);
                    break;

                case ENUMS.MOVETYPE.RIGHTUP:
                    SetAnimSprites(RightUpTiltAnims);
                    break;

                case ENUMS.MOVETYPE.RIGHTDOWN:
                    SetAnimSprites(RightDownTiltAnims);
                    break;

                case ENUMS.MOVETYPE.LEFTUP:
                    SetAnimSprites(LeftUpTiltAnims);
                    break;

                case ENUMS.MOVETYPE.LEFTDOWN:
                    SetAnimSprites(LeftDownTiltAnims);
                    break;
            }
        }
    }

    /// <summary>
    /// アニメーション画像を設定する
    /// </summary>
    private void SetAnimSprites(Sprite[] _animSprites)
    {
        //画像数の限界に達したとき
        if (AnimNum == _animSprites.Length)
        {
            //最初からにする
            AnimNum = 0;
        }

        WaitAfter(0.08f, () =>
        {
            //画像設定
            Renderer.sprite = _animSprites[AnimNum];

            MovingFlg = false;
        });
    }
}