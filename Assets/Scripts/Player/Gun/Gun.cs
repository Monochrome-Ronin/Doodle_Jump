using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Camera _camera;
    [SerializeField] private SpriteRenderer _gunRender;
    [SerializeField] private AudioClip _shootClip;
    [SerializeField] private Bullet _bullet;
    [SerializeField] private Transform _bulletDir;
    [SerializeField] private GameUIController _gameUIController;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && Time.timeScale != 0)
        {
            StopCoroutine(Shoot(Input.mousePosition));
            StartCoroutine(Shoot(Input.mousePosition));
        }
    }
    private IEnumerator Shoot(Vector3 positionShoot)
    {
        AudioController.Instance.PlaySound(_shootClip);
        _player.IsShoot = true;
        _player.SootAnim();
        _gunRender.color = new Color(1, 1, 1, 1);
        Vector3 diff = _camera.ScreenToWorldPoint(positionShoot) - transform.position;
        diff.Normalize();
        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, Mathf.Clamp(rot_z - 90, -45, 45));
        Instantiate(_bullet, _bulletDir.position, transform.rotation);     
        yield return new WaitForSeconds(1f);
        _gunRender.color = new Color(1, 1, 1, 0);
        _player.IsShoot = false;
        _player.IdelAnim();
    }
}
