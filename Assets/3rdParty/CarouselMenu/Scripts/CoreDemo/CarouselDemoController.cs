using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CarouselDemoController : MonoBehaviour
{
  public CarouselController _carouselController;
  public Dropdown _carouselStyle;
  public Toggle _autoFocusToggle;
  public Toggle _selectFocusToggle;
  public Toggle _shouldLoopToggle;
  public Toggle _isHorizontalToggle;
  public Slider _coverFlowAngleXSlider;
  public Slider _coverFlowAngleYSlider;
  public Slider _coverFlowAngleZSlider;
  public Slider _cellGapSlider;
  public Slider _scaleXSlider;
  public Slider _scaleYSlider;

  public void OnBackBtnDown()
  {
    SceneManager.LoadScene("CarouselStartScene");
  }

  public void OnCarouselStyleChange()
  {
    switch(_carouselStyle.value)
    {
      case 0:
        _carouselController._carouselType = CarouselConstants.iCarouselType.iCarouselTypeLinear;
        break;
      case 1:
        _carouselController._carouselType = CarouselConstants.iCarouselType.iCarouselTypeScaledLinear;
        break;
      case 2:
        _carouselController._carouselType = CarouselConstants.iCarouselType.iCarouselTypeCoverFlow;
        break;
      case 3:
        _carouselController._carouselType = CarouselConstants.iCarouselType.iCarouselTypeScaledCoverFlow;
        break;
    }
  }
  
  public void OnScaleValueChanged()
  {
    _carouselController._scaleRatio = new Vector3(_scaleXSlider.value, _scaleYSlider.value, _carouselController._scaleRatio.z);
  }
  
  public void OnCellGapSliderValueChanged()
  {
    _carouselController._cellGap = _cellGapSlider.value;
  }
  
  public void OnCoverFlowSliderValueChanged()
  {
    _carouselController._coverflowAngles = new Vector3(_coverFlowAngleXSlider.value, _coverFlowAngleYSlider.value, _coverFlowAngleZSlider.value);
  }
  
  public void OnAutoFocusToggleValueChanged()
  {
    _carouselController._shouldFocusCenter = _autoFocusToggle.isOn;
  }
  
  public void OnSelectFocusToggleValueChanged()
  {
    _carouselController._shouldCenterSelect = _selectFocusToggle.isOn;
  }
  
  public void OnShouldLoopValueChanged()
  {
    _carouselController._shouldLoop = _shouldLoopToggle.isOn;
  }
  
  public void OnIsHorizontalValueChanged()
  {
    _carouselController._isHorizontal = _isHorizontalToggle.isOn;
  }
  
  public void OnCellDown(int arrayIndex, int cellIndex)
  {
    Debug.Log("Select: " + arrayIndex + " cell index:" + cellIndex);
  }
  
  void OnEnable()
  {
    _carouselController._onCellClickedEvent.AddListener(OnCellDown);
  }

  void OnDisable()
  {
    _carouselController._onCellClickedEvent.RemoveListener(OnCellDown);
  }
}