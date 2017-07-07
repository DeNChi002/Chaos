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
        //上移動
		if(InputManager.Vertical > 0.0f)
        {
            MoveAnimation(ENUMS.MOVETYPE.UP);
        }
        //下移動
        else if(InputManager.Vertical < 0.0f)
        {
            MoveAnimation(ENUMS.MOVETYPE.DOWN);
        }
        //右移動
        else if(InputManager.Horizontal > 0.0f)
        {
            MoveAnimation(ENUMS.MOVETYPE.RIGHT);
        }
        //左移動
        else if (InputManager.Horizontal < 0.0f)
        {
            MoveAnimation(ENUMS.MOVETYPE.LEFT);
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