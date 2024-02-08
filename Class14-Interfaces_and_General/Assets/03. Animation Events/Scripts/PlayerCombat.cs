using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public float damage = 10f;
    public GameObject damageTextPrefab;

    public void DisplayDamage()
    {
        GameObject damageTextInstance = Instantiate(damageTextPrefab, transform.position, Quaternion.identity);
        TextMesh damageText = damageTextInstance.GetComponentInChildren<TextMesh>();
        damageText.text = damage.ToString();
    }
}
