using UnityEngine;
using UnityEngine.UI;

public class HealthBarController : MonoBehaviour
{
    [SerializeField] private Image healthBarImage;
    private Unit unit;

    private Vector3 Cameratransform;

    void Start()
    {
        Cameratransform = Camera.main.transform.position;
        unit = GetComponentInParent<Unit>();
    }

    void Update()
    {
        UpdateHealthBar();
    }

    private void UpdateHealthBar()
    {
        if (unit != null)
        {
            transform.LookAt(Cameratransform);
            float healthPercentage = (float)unit.Health / unit.MaxHealth;
            healthBarImage.fillAmount = healthPercentage;
        }
    }
}