using UnityEngine;
using UnityEngine.UI;

public class Valuable : MonoBehaviour
{
    [SerializeField] int value;
    [SerializeField] Text money;

    int moneyAmount = 0;
    bool canBePickedUp;
    private Transform player;
    BoxCollider boxCollider;
    

    public void Steal()
    {
        moneyAmount += value;

        money.text = moneyAmount.ToString();

        boxCollider.enabled = false;
        canBePickedUp = true;
    }

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        boxCollider = GetComponent<BoxCollider>();
    }

    private void Update()
    {
        if (canBePickedUp)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.position, 25 * Time.unscaledDeltaTime);

            if (transform.position == player.transform.position)
            {
                Destroy(gameObject);
            }
        }
    }
}
