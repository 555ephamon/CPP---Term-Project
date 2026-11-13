using UnityEngine;

public class SimplePickup : MonoBehaviour
{
    public enum PickupType
    {
        Health,
        JumpBoost,
        Score,
        RangedAttack,
    }

    [SerializeField] private PickupType type;
    [SerializeField] private int scoreAmount;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerController controller = collision.GetComponent<PlayerController>();

            switch (type)
            {

                case PickupType.Health:
                    //C++ style
                    //controller.SetLives(controller.GetLives() +1
                    controller.lives++;
                    break;


                case PickupType.JumpBoost:
                    controller.JumpForceChange();
                    break;

                case PickupType.Score:
                    controller.score += scoreAmount;
                    break;

                case PickupType.RangedAttack:
                    controller.RangedAttack();
                    break;
            }

            Destroy(gameObject);
        }

    }
}
