using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace PolskiPolakPL.Utils.UI
{
    [ExecuteAlways]
    public class UIColorPallet : MonoBehaviour
    {
        [Header("- - - = = Serializable Colors = = - - -")]
        [SerializeField] List<ColorStyle> colorStyles = new List<ColorStyle>();

        // Update is called once per frame
        void Update()
        {
            //Serializable
            foreach (ColorStyle style in colorStyles)
            {
                if (style == null)
                    continue;
                ApplyColorToImages(style.Color, style.ImagesList);
                ApplyColorToTexts(style.Color, style.TextsList);
            }
        }


        void ApplyColorToImages(Color color, List<Image> imagesList)
        {
            if (isValidList(imagesList))
                foreach (Image image in imagesList)
                {
                    image.color = color;
                }
        }
        void ApplyColorToTexts(Color color, List<TMP_Text> textsList)
        {
            if (isValidList(textsList))
                foreach (TMP_Text text in textsList)
                {
                    text.overrideColorTags = true;
                    text.color = color;
                }
        }
        bool isValidList(List<Image> imageList)
        {
            bool isValid = true;
            foreach (Image image in imageList)
            {
                if (image == null)
                {
                    isValid = false;
                    break;
                }
            }
            return imageList.Count > 0 && isValid;
        }
        bool isValidList(List<TMP_Text> textList)
        {
            bool isValid = true;
            foreach (TMP_Text text in textList)
            {
                if (text == null)
                {
                    isValid = false;
                    break;
                }
            }
            return textList.Count > 0 && isValid;
        }

    }
    [System.Serializable]
    class ColorStyle
    {
        public Color Color = new Color(250, 250, 250, 250);
        public List<Image> ImagesList = new List<Image>();
        public List<TMP_Text> TextsList = new List<TMP_Text>();

    }
}