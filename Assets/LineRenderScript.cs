using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class AttackWarning : MonoBehaviour
{
    private LineRenderer lineRenderer;
    public Transform boss;        // Vị trí của boss
    public Transform player;      // Vị trí của người chơi
    public float warningTime = 2f;  // Thời gian cảnh báo trước khi tấn công

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 2;  // Đường kẻ giữa hai điểm
    }

    public void ShowWarning()
    {
        StartCoroutine(ShowWarningCoroutine());
    }

    private IEnumerator ShowWarningCoroutine()
    {
        // Hiển thị đường cảnh báo
        lineRenderer.enabled = true;
        lineRenderer.SetPosition(0, boss.position);
        lineRenderer.SetPosition(1, player.position);

        // Chờ trong thời gian cảnh báo
        yield return new WaitForSeconds(warningTime);

        // Ẩn đường cảnh báo
        lineRenderer.enabled = false;

        // Thực hiện tấn công ở đây (gọi hàm tấn công của boss)
        // BossAttack();
    }

    void Update()
    {
        if (lineRenderer.enabled)
        {
            // Cập nhật vị trí của đường cảnh báo liên tục
            lineRenderer.SetPosition(0, boss.position);
            lineRenderer.SetPosition(1, player.position);
        }
    }
}