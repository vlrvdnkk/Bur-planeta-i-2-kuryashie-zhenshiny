using UnityEngine;

public class RotationScript : MonoBehaviour
{
    public SpriteRenderer spriteRenderer; // Ссылка на компонент SpriteRenderer объекта
    public Sprite normalSprite; // Обычный спрайт
    public Sprite mirroredSprite; // Зеркальный спрайт

    void Update()
    {
        Rotation();
    }

    void Rotation()
    {
        Vector3 worldPos = Input.mousePosition;
        worldPos = Camera.main.ScreenToWorldPoint(worldPos);

        // Вычисляем угол между текущей позицией объекта и позицией мыши
        float angle = Mathf.Atan2(worldPos.y - transform.position.y, worldPos.x - transform.position.x) * Mathf.Rad2Deg;

        // Вращаем объект вокруг оси Z на 360 градусов
        transform.rotation = Quaternion.Euler(0, 0, angle - 90);

        // В зависимости от угла, выбираем спрайт
        if ((angle >= 0 && angle < 90) || (angle >= -90 && angle < 0))
        {
            spriteRenderer.sprite = mirroredSprite; // Зеркальный спрайт
        }
        else
        {
            spriteRenderer.sprite = normalSprite; // Обычный спрайт
        }
    }
}