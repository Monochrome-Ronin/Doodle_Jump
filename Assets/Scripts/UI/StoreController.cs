using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Events;

public class StoreController : MonoBehaviour
{
    [SerializeField] private SimplePlatform[] _simplePlatforms;
    public void StoreAnimation(SimplePlatform platform)
    {
        foreach (SimplePlatform simplePlatform in _simplePlatforms)
        {
            simplePlatform.SetJump(false);
            if (platform.gameObject.GetInstanceID() == simplePlatform.gameObject.GetInstanceID()) simplePlatform.SetJump(true);
        }
    }
}
