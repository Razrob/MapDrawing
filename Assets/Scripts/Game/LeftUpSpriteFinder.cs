using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeftUpSpriteFinder : MonoBehaviour
{
    [SerializeField] private Text _text;
    [SerializeField] private Camera _camera;

    private void OnEnable()
    {
        RaycastHit2D[] _hits = Physics2D.RaycastAll(_camera.ScreenToWorldPoint(new Vector3(0, _camera.pixelHeight)), Vector3.forward);
        if(_hits.Length > 0) if (_hits[0].transform.TryGetComponent(out SpriteRenderer _spriteRenderer)) _text.text = _spriteRenderer.sprite.name;
    }
}
