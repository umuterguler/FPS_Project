using UnityEngine;

namespace Enemy
{
    [CreateAssetMenu(fileName = "Enemy Stats", menuName = "Enemy/Stats")]
    public class EnemyStats : ScriptableObject
    {
        public string enemyName;
        public int enemyMaxHealth;
    
    }  
}


