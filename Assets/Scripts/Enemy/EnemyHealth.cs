using Interfaces;
using UnityEngine;
using UnityEngine.UI;

namespace Enemy
{
    public class EnemyHealth : MonoBehaviour , IDamageable
    {
        [Header("Enemy Stats")]//Dusman Statlari Scriptable Object
        [SerializeField] private EnemyStats enemyStats;
        
        [Header("Health Bar")]//Fill Image Icin Gerekli Seyler
        [SerializeField] private Slider healthBarSlider;
        [SerializeField] private Image fillImage;
        [SerializeField] private Color maxHealthColor;
        [SerializeField] private Color zeroHealthColor;
        [SerializeField] private GameObject damageTextPrefab;
        
        private int _currentHealth;
        
        private void Start()
        {
            _currentHealth = enemyStats.enemyMaxHealth;
        }
        
        public void DealDamage(int damage) //Hasar Verme, Oldu mu Kontrolu ve Can Barini Set Etme
        {
            _currentHealth -= damage;
            Instantiate(damageTextPrefab, transform.position, Quaternion.identity).GetComponent<DamageText>().Initialise(damage);
            CheckIfDead();
            SetHealthBarUi();
        }

        private void CheckIfDead() //Oldu mu Eger Olduyse Objeyi Yok Et
        {
            if (_currentHealth <= 0)
            {
                Destroy(gameObject);
            }
        }

        private void SetHealthBarUi() //Can Barinin Rengini ve Azalmasini Set Et
        {
            float healthPercentage = CalculateHealthPercentage();
            healthBarSlider.value = healthPercentage;
            //Color.Lerp metodu iki renk arasinda orantili bir gecis yapar. 
            fillImage.color = Color.Lerp(zeroHealthColor, maxHealthColor, healthPercentage / 100);
        }

        private float CalculateHealthPercentage() // Can degerini 100'e referansla oranla.(Yuzde Alma)
        {
            return ((float)_currentHealth / (float)enemyStats.enemyMaxHealth) * 100f;
        }
    }
}








