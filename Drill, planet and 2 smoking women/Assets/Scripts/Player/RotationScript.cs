using UnityEngine;

public class RotationScript : MonoBehaviour
{
    public SpriteRenderer spriteRenderer; // ������ �� ��������� SpriteRenderer �������
    public Sprite normalSprite; // ������� ������
    public Sprite mirroredSprite; // ���������� ������

    void Update()
    {
        Rotation();
    }

    void Rotation()
    {
        Vector3 worldPos = Input.mousePosition;
        worldPos = Camera.main.ScreenToWorldPoint(worldPos);

        // ��������� ���� ����� ������� �������� ������� � �������� ����
        float angle = Mathf.Atan2(worldPos.y - transform.position.y, worldPos.x - transform.position.x) * Mathf.Rad2Deg;

        // ������� ������ ������ ��� Z �� 360 ��������
        transform.rotation = Quaternion.Euler(0, 0, angle - 90);

        // � ����������� �� ����, �������� ������
        if ((angle >= 0 && angle < 90) || (angle >= -90 && angle < 0))
        {
            spriteRenderer.sprite = mirroredSprite; // ���������� ������
        }
        else
        {
            spriteRenderer.sprite = normalSprite; // ������� ������
        }
    }
}