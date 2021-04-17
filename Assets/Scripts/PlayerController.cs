using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.ThirdPerson;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

    public Camera cam;

    public NavMeshAgent agent;

    public ThirdPersonCharacter character;
    public GameObject Enemy;

    void Start() {
        agent.updateRotation = false;
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit)) {
                agent.SetDestination(hit.point);
            }
        }

        if (agent.remainingDistance > agent.stoppingDistance) {
            character.Move(agent.desiredVelocity, false, false);
        }
        else {
            character.Move(Vector3.zero, false, false);
        }

    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Pellet") {
            other.gameObject.SetActive(false);
            Display.score = Display.score + 10;
            if (Display.score >= 790) {
                SceneManager.LoadScene("CreditsScene");
            }
        }
        if(other.gameObject.tag == "Enemy") {
            Display.lives = Display.lives - 1;
            if (Display.lives == 0) {
                SceneManager.LoadScene("CreditsScene");
            }

            transform.position = new Vector3(0, 0.54f, -3);

            Enemy.GetComponent<NavMeshAgent>().enabled = false;
            Enemy.transform.localPosition = new Vector3(0.12f, 1, 1f);
            Enemy.GetComponent<NavMeshAgent>().enabled = true;
        }
    }
}