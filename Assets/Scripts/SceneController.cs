using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SceneController : MonoBehaviour, IPointerDownHandler
{
    public Snowman snowman;
    public int lives;
    public Button button;

    private Snowman currentSnowman;

    private void Awake()
    {
        button.onClick.AddListener(HandleSnowmanDied);
        Lean.Touch.LeanTouch.OnFingerSwipe += HandleFingerSwipe;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (currentSnowman != null)
                currentSnowman.Died -= HandleSnowmanDied;
            currentSnowman = Instantiate(snowman);
            currentSnowman.Died += HandleSnowmanDied;
            currentSnowman.transform.localPosition = new Vector3(Random.RandomRange(-1, 1), Random.RandomRange(-1, 1), Random.RandomRange(-1, 1));
        }
    }

    public void HandleSnowmanDied()
    {
        Debug.Log("Snowman died");
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        HandleSnowmanDied();
    }

    void HandleFingerSwipe(Lean.Touch.LeanFinger finger)
    {
        HandleSnowmanDied();
    }
}
