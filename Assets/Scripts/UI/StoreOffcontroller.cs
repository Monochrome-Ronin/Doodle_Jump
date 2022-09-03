using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Events;

public class StoreOffcontroller : MonoBehaviour
{
    [SerializeField] private SimplePlatform[] _simplePlatforms;
    [SerializeField] private Button[] _buttons;

    private void Start()
    {
        foreach (Button button in _buttons)
        {
            button.onClick.AddListener(OffStoreAnimation);
            UnityEventCallState odfStoreAnimation = button.onClick.GetPersistentListenerState(2);
            button.onClick.SetPersistentListenerState(0, odfStoreAnimation);
        }
    }
    private void OffStoreAnimation()
    {
        foreach (SimplePlatform simplePlatform in _simplePlatforms)
        {
            simplePlatform.SetJump(false);
        }
    }
}
