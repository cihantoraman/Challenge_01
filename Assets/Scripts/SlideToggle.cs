using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SlideToggle : MonoBehaviour, IPointerDownHandler
{
    public GameObject slider;
    public AnimationCurve curve;
    private bool isOn;
    private float time;
    public float duration = 1.0f;
    [SerializeField] private GameObject startPoint;
    [SerializeField] private GameObject endPoint;
    private Image sliderImage;
    public Color onColor = Color.green; // Add this line
    public Color offColor = Color.white; // Add this line

    // Use this for initialization
    void Start()
    {
        isOn = false;
        time = 0;
        duration = 1f;
        sliderImage = slider.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        time += (1/duration) * Time.deltaTime;
        float y1 = startPoint.transform.localPosition.x;
        float y2 = endPoint.transform.localPosition.x;

        if (isOn)
        {
            // Move the slider to the right
            float x = Mathf.Lerp(slider.transform.localPosition.x, y2, curve.Evaluate(time));
            slider.transform.localPosition = new Vector3(x, 0, 0);
            sliderImage.color = onColor; // Modify this line
        }
        else
        {
            // Move the slider to the left
            float x = Mathf.Lerp(slider.transform.localPosition.x, y1, curve.Evaluate(time));
            slider.transform.localPosition = new Vector3(x, 0, 0);
            sliderImage.color = offColor; // Modify this line
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        // Toggle the state of the slide toggle button
        isOn = !isOn;
        time = 0; // Reset the time whenever we toggle the button
    }
}
