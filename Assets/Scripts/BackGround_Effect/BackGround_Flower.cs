using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 背景エフェクト：フラワー
/// </summary>
public class BackGround_Flower : MonoBehaviour
{
    const float MAXSCALE = 11.22f;
    const float MINSCALE = 0.0f;

    [SerializeField,Header("FlowerのImage群")]
    Image[] Sprite_Flowers;

    Color[] SpriteColors = { Color.red, Color.blue, Color.green, Color.yellow};

    //オフセット用スケール
    float[] OffsetScales = { 0.1f, 0.22f, 0.49f, 1.06f, 2.31f, 5.05f, 11.22f };

    //画像を不透明にするためのColorスケール
    Color[] VisibleColor = new Color[7];

    void Start()
    {
        for(int i = 0;i < OffsetScales.Length; i++)
        {
            Sprite_Flowers[i].rectTransform.localScale = new Vector3(OffsetScales[i], OffsetScales[i], OffsetScales[i]);
            Sprite_Flowers[i].rectTransform.localEulerAngles = new Vector3(0, 0, 180);

            //色を設定
            Sprite_Flowers[i].color = SpriteColors[Random.Range(0, SpriteColors.Length)];
            VisibleColor[i] = new Color(Sprite_Flowers[i].color.r, Sprite_Flowers[i].color.g, Sprite_Flowers[i].color.b, 0);
        }
    }

	void LateUpdate ()
    {
		for(int i = 0;i < Sprite_Flowers.Length; i++)
        {
            //縮小する
            Sprite_Flowers[i].rectTransform.localScale = Vector3.Lerp(Sprite_Flowers[i].rectTransform.localScale, new Vector3(MINSCALE, MINSCALE, MINSCALE), 1 * Time.deltaTime);

            //回転させる
            Vector3 Euler = Sprite_Flowers[i].rectTransform.localEulerAngles;
            Euler.z += 30 * Time.deltaTime;
            Sprite_Flowers[i].rectTransform.localEulerAngles = Euler;

            if(Sprite_Flowers[i].rectTransform.localScale.x < 0.7f)
            {
                Sprite_Flowers[i].color = Color.Lerp(Sprite_Flowers[i].color, VisibleColor[i], 2 * Time.deltaTime);
            }          

            //最小値まで縮小した場合
            if (Sprite_Flowers[i].rectTransform.localScale.x < 0.05f)
            {
                //再度縮小できるように設定する
                Sprite_Flowers[i].rectTransform.localScale = new Vector3(MAXSCALE, MAXSCALE, MAXSCALE);
                Sprite_Flowers[i].rectTransform.localEulerAngles = new Vector3(0, 0, 180);

                //色を設定
                Sprite_Flowers[i].color = SpriteColors[Random.Range(0, SpriteColors.Length)];
                VisibleColor[i] = new Color(Sprite_Flowers[i].color.r, Sprite_Flowers[i].color.g, Sprite_Flowers[i].color.b, 0);
            }
        }
	}
}