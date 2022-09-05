using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkinPlayerManager : MonoBehaviour
{
    [SerializeField] private PlayerMover _player;
    [SerializeField] private PlayerSkin[] _playerSkins;
    private void Start()
    {
        SetSkin();
    }

    public void SetSkin()
    {
        _player.IdleSprite = _playerSkins[Saver.GetIntPrefs("CurrentSkin")].IdelSprite;
        _player.JumpSprite = _playerSkins[Saver.GetIntPrefs("CurrentSkin")].JumpSprite;
    }
}
