using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(Image))]
public class PhotoGallery : AppController
{

    Image image;

    private void Awake()
    {
        image = GetComponent<Image>();
    }

    public void SetTexture(Texture2D tex)
    {
        //public static Sprite Create
        //(Texture2D texture, Rect rect, Vector2 pivot, float pixelsPerUnit, uint extrude);
        Rect rect = new Rect(0, 0, tex.width, tex.height);
        //pivot at center
        Vector2 pivot = new Vector2(0.5f, 0.5f);
        Sprite _sprite = Sprite.Create(tex, rect, pivot);
        //set sprite of ui image
        image.sprite = _sprite;
    }
}
