using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(PlayerResourcesController))]
public class PlayerController : MonoBehaviour
{
	[HideInInspector] public bool isRunning = false;

    public float playerHpStart = 100;
    public float playerHpCurrent = 100;

    public float playerTerrainSpeed = 1;

    public float playerSpeedMove = 1;
    public float swordDamage = 1;
    public float axeDamage = 1;
    public float pickaxeDamage = 1;
    public float loot = 1;
    public float darknessSpeed = 1;
    public Image hpbar;

    private PlayerResourcesController playerResourcesController;

    private void Start()
    {
        playerResourcesController = GetComponent<PlayerResourcesController>();
    }

    public int GetDamage(UpgradableTools type)
    {
        switch (type)
        {
            case UpgradableTools.Sword:
                return Mathf.RoundToInt(playerResourcesController.sword.effect * swordDamage);

            case UpgradableTools.Axe:
                return Mathf.RoundToInt(playerResourcesController.axe.effect * axeDamage);

            case UpgradableTools.Pickaxe:
                return Mathf.RoundToInt(playerResourcesController.pickaxe.effect * axeDamage);

                default: return 0;
        }
    }

    private void Update()
    {
        playerHpCurrent = Mathf.Min(playerHpStart, playerHpCurrent += 0.005f);
        hpbar.fillAmount = playerHpCurrent / playerHpStart;
    }

    public void PlayerDamaged(float damage)
    {
        playerHpCurrent -= damage;
        Debug.Log(playerHpCurrent);
        if (playerHpCurrent < 0)
        {
            SceneManager.LoadScene("MenuScene");
        }
    }
}

