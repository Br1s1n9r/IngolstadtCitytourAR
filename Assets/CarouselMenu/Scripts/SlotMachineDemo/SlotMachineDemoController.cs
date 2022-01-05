using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SlotMachineDemoController : MonoBehaviour
{
  public List<CarouselController> _carouselList;
  public float _force = 1000;
  public float _minRandomRatio = 0.5f;
  public float _maxRandomRatio = 0.5f;

  public void OnBackBtnDown()
  {
    SceneManager.LoadScene("CarouselStartScene");
  }

  public void OnSpinBtnDown()
  {
    foreach(var controller in _carouselList)
    {
      if (controller._isHorizontal)
        controller._scroll.velocity = new Vector2(1, 0) * (_force * Random.Range(_minRandomRatio, _maxRandomRatio));
      else
        controller._scroll.velocity = new Vector2(0, 1) * (_force * Random.Range(_minRandomRatio, _maxRandomRatio));
    }
  }
}
