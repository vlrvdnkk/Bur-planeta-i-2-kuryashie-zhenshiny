using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BaseButton : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private HpBar _hp;
    [SerializeField] private GameController _gc;
    [SerializeField] private TextMeshProUGUI _text;
    private int _price;
    void Start()
    {
        _price = 100;
        _text.text = _price.ToString();
        _button.onClick.AddListener(() => Click());
    }

    void Click()
    {
        if (_gc.score > _price)
        {
            _gc.score -= _price;
            _price *= 2;
            _hp.Start();
            _text.text = _price.ToString();
        }
        else
            _gc.Red();
    }
}
