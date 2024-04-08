using UnityEngine;

public class PlayerController : MonoBehaviour
{
    IInput input;
    Carlos.PlayerMovement movement;
    [SerializeField] private LayerMask picbkableLayerMask;
    [SerializeField] private GameObject pickUpUI;
    [SerializeField] private Transform playerPickeableTransform;

    private const float HIT_RANGE = 3;
    private RaycastHit hit;

    private  void OnEnable() {
        input = GetComponent<IInput>();
        movement = GetComponent<Carlos.PlayerMovement>();
        input.OnMovementDirectionInput += movement.HandleMovementDirection;
        input.OnMovementInput += movement.HandleMovement;
    }

    private void OnDisable() {
        input.OnMovementDirectionInput -= movement.HandleMovementDirection;
        input.OnMovementInput -= movement.HandleMovement;
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Enemy")) {
            print("Player Die");
        }
    }

    private void Update() {

        Debug.DrawRay(playerPickeableTransform.position, playerPickeableTransform.forward * HIT_RANGE, Color.red);

        if (hit.collider != null) {
            pickUpUI.SetActive(false);
            hit.collider.gameObject.GetComponent<ObjectRotation>().setIsTargeted(false);            
        }

        if (Physics.Raycast(playerPickeableTransform.position, playerPickeableTransform.forward, out hit, HIT_RANGE, picbkableLayerMask)) {
            pickUpUI.SetActive(true);
            hit.collider.gameObject.GetComponent<ObjectRotation>().setIsTargeted(true);
            HandlePickUpObject();
        }
    }

    private void HandlePickUpObject() {
        if (Input.GetKeyUp("e") && hit.collider != null) {
            Debug.Log(hit.collider.gameObject.name);
            GameManager.Instance.foundKey();
            pickUpUI.SetActive(false);
            hit.collider.gameObject.SetActive(false);
        }
    }

    
}
