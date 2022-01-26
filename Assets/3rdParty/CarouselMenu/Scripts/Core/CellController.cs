using System;
using UnityEngine;
using UnityEngine.UI;

public class CellEventArgs : EventArgs
{
    public int Index;

    public CellEventArgs(int i)
    {
        Index = i;
    }
}

public class CellController : MonoBehaviour
{
    public event EventHandler<CellEventArgs> Clicked;
    public int _index;
    public Text _desc;
    public Sprite targetImage;
    Image buttonImage;

    private bool clicked = false;

    public delegate void OnButtonHit(int _index);

    public static OnButtonHit onButtonHit;


    public void UpdateDesc(string desc)
    {
        if (_desc == null)
            return;
        _desc.text = "";
        gameObject.GetComponentInParent<Image>().sprite = targetImage;
    }

    public void OnBtnDown()
    {
        Clicked?.Invoke(this, new CellEventArgs(_index));

        if (onButtonHit != null)
        {
            if (clicked == true)
            {
                Debug.Log("Clicky");
                onButtonHit(_index);
            }

            clicked = !clicked;
        }
    }
}