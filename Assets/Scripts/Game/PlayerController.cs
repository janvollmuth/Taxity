using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [Header("Player")]
    public int Player;
    public GameObject Parent;

    [Header("Control")]
    public DirectionDropdown direction;
    public float Speed;
    public float RotationSpeed;
    public GameObject NextWaypoint;

    [Header("Canvas")]
    public Image PickUpButtonImage;
    public Image BoostButton;
    public Image ImageNorth;
    public Image ImageEast;
    public Image ImageWest;
    public GameObject WinScreen;
    public TextMeshProUGUI PickUpCounter;


    [Header("References")]
    public InGameAudioHandler AudioHandler;
    public Camera cam;
    public NavMeshAgent agent;
    private GameObject human;
    private bool npcAround;
    private Animator animator;
    private float duration;
    private bool parabolEnded = true;
    private bool boostAvailable = true;

    // Start is called before the first frame update
    void Start()
    {

        if (Player == 1)
        {
            GameManager.Instance.Player1Position = transform;
        }
        else if (Player == 2)
        {
            GameManager.Instance.Player2Position = transform;
        }

        agent.updateRotation = false;

        animator = GetComponent<Animator>();

        StartCoroutine(CoroutinePlayer());
    }

    // Update is called once per frame
    void Update()
    {
        if (parabolEnded)
        {
            GetComponent<RectTransform>().anchoredPosition3D = new Vector3(0, 0, 0);
        }

        if (Player == 1)
        {
            if (!GameManager.Instance.IsRunning || GameManager.Instance.Player1Stopped)
            {
                agent.speed = 0;
                return;
            }
            else
            {
                agent.speed = Speed;
            }
            HandleInputPlayer1();
        }

        if(Player == 2)
        {
            if (!GameManager.Instance.IsRunning || GameManager.Instance.Player2Stopped)
            {
                agent.speed = 0;
                return;
            }
            else
            {
                agent.speed = Speed;
            }
            HandleInputPlayer2();
        }
        StartCoroutine(CoroutinePlayer());
    }

    private IEnumerator CoroutinePlayer()
    {
        UpdatePlayer();
        UpdatePlayerUI();
        UpdatePlayerScore();
        UpdateGameManager();

        yield return null;
    }

    private void UpdatePlayer()
    {
        MoveTowardsNew();
        RotateTowards();
    }

    private void RotateTowards()
    {
        Vector3 direction = (NextWaypoint.transform.position - Parent.transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        Parent.transform.rotation = Quaternion.Slerp(Parent.transform.rotation, lookRotation, Time.deltaTime * RotationSpeed);
    }

    public void MoveTowardsNew()
    {
        float distance = Vector3.Distance(NextWaypoint.transform.position, Parent.transform.position);

        if(distance > 0.1)
        {
            Vector3 movement = Parent.transform.forward * Time.deltaTime * Speed;

            agent.Move(movement);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name.Contains("WayPoint") && other.gameObject.GetComponent<WayPointManager_v2>().type == 0)
        {
            GameObject entry = other.gameObject;
            string dir = direction.Direction[direction.listIndex];
            NextWaypoint = entry.GetComponent<WayPointManager_v2>().GetSelectedCrossingOption(dir, animator);
            direction.listIndex = 0;
        }

        if (other.name.Contains("Human") && other.gameObject.name != null)
        {
            human = other.gameObject;
            PickUpButtonImage.gameObject.SetActive(true);
            npcAround = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.name.Contains("Human"))
        {
            human.GetComponentInParent<HumanAI>().CalcualteParabola(Player);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name.Contains("Human"))
        {
            human = other.gameObject;
            PickUpButtonImage.gameObject.SetActive(false);
            npcAround = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.Contains("NPC"))
        {
            return;
        }

        if(collision.gameObject.name.Contains("Taxi") && !GameManager.Instance.BoostOnP1 && !GameManager.Instance.BoostOnP2)
        {
            return;
        }

        if (Player == 1 && !GameManager.Instance.BoostOnP1 && parabolEnded)
        {
            Debug.Log("Kollision mit " + collision.gameObject.name);

            if (collision.gameObject.GetComponent<PlayerController>().Player == 2)
            {
                if(GameManager.Instance.PickedUpCostumersP1 > 0)
                {
                    GameManager.Instance.PickedUpCostumersP1--;
                    GameManager.Instance.PickedUpCostumersP2++;
                }

                parabolEnded = false;
                GameManager.Instance.Player1Stopped = true;

                GetComponent<ParabolaController>().FollowParabola();
                duration = GetComponent<ParabolaController>().GetDuration();
                StartCoroutine(CoroutineAnimationDuration());
            }
        }
        else if(Player == 2 && !GameManager.Instance.BoostOnP2 && parabolEnded)
        {
            Debug.Log("Kollision mit " + collision.gameObject.name);

            if (collision.gameObject.GetComponent<PlayerController>().Player == 1)
            {
                if (GameManager.Instance.PickedUpCostumersP2 > 0)
                {
                    GameManager.Instance.PickedUpCostumersP1++;
                    GameManager.Instance.PickedUpCostumersP2--;
                }

                parabolEnded = false;
                GameManager.Instance.Player2Stopped = true;

                GetComponent<ParabolaController>().FollowParabola();
                duration = GetComponent<ParabolaController>().GetDuration();
                StartCoroutine(CoroutineAnimationDuration());
            }
        }
    }

    private IEnumerator CoroutineAnimationDuration()
    {
        yield return new WaitForSeconds(duration);

        parabolEnded = true;
        GetComponent<Rigidbody>().velocity = new Vector3(0,0,0);

        if(Player == 1)
        {
            GameManager.Instance.Player1Stopped = false;
        }

        if(Player == 2)
        {
            GameManager.Instance.Player2Stopped = false;
        }
    }

    private IEnumerator CoroutineDeactivatePickable()
    {
        yield return new WaitForSeconds(0.85f);

        PickUpButtonImage.gameObject.SetActive(false);
        npcAround = false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, NextWaypoint.transform.position);
    }

    private void HandleInputPlayer1()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            direction.listIndex = 0;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            direction.listIndex = 1;
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            direction.listIndex = 2;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && npcAround)
        {
            animator.SetTrigger("Stop");
            human.GetComponentInParent<HumanAI>().DeactivateHuman(1);
            GameManager.Instance.Player1Stopped = true;
            AudioHandler.PlayPickUpSound();

            StartCoroutine(CoroutineDeactivatePickable());

            GameManager.Instance.ActualPickableHumans--;
            GameManager.Instance.PickedUpCostumersP1++;
        }
        else if(Input.GetKeyDown(KeyCode.E) && boostAvailable)
        {
            StartCoroutine(CoroutineBoost());
            StartCoroutine(CoroutineBoostCooldown());
        }
    }

    private void HandleInputPlayer2()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            direction.listIndex = 0;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            direction.listIndex = 1;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            direction.listIndex = 2;
        }
        else if (Input.GetKeyDown(KeyCode.RightControl) && npcAround)
        {
            animator.SetTrigger("Stop");
            human.GetComponentInParent<HumanAI>().DeactivateHuman(2);
            GameManager.Instance.Player2Stopped = true;
            AudioHandler.PlayPickUpSound();

            StartCoroutine(CoroutineDeactivatePickable());

            GameManager.Instance.ActualPickableHumans--;
            GameManager.Instance.PickedUpCostumersP2++;
        }
        else if (Input.GetKeyDown(KeyCode.RightShift) && boostAvailable)
        {
            StartCoroutine(CoroutineBoost());
            StartCoroutine(CoroutineBoostCooldown());
        }
    }

    private IEnumerator CoroutineBoost()
    {
        Speed = 8f;
        RotationSpeed = 4f;
        animator.speed *= 2f;

        AudioHandler.GetEngineSound().pitch = 3;

        if(Player == 1)
        {
            GameManager.Instance.BoostOnP1 = true;
        }
        else if(Player == 2)
        {
            GameManager.Instance.BoostOnP2 = true;
        }


        yield return new WaitForSecondsRealtime(5f);

        Speed = 5f;
        RotationSpeed = 2.5f;
        animator.speed /= 2f;

        AudioHandler.GetEngineSound().pitch = 2;

        if (Player == 1)
        {
            GameManager.Instance.BoostOnP1 = false;
        }
        else if (Player == 2)
        {
            GameManager.Instance.BoostOnP2 = false;
        }
    }

    private IEnumerator CoroutineBoostCooldown()
    {
        boostAvailable = false;
        BoostButton.gameObject.SetActive(false);

        yield return new WaitForSecondsRealtime(10f);

        boostAvailable = true;
        BoostButton.gameObject.SetActive(true);
    }

    private void UpdatePlayerScore()
    {
        if (Player == 1)
        {
            PickUpCounter.SetText(GameManager.Instance.PickedUpCostumersP1.ToString());
        }
        else
        {
            PickUpCounter.SetText(GameManager.Instance.PickedUpCostumersP2.ToString());
        }
    }

    private void UpdatePlayerUI()
    {
        switch (direction.Direction[direction.listIndex])
        {
            case "North":
                ImageNorth.gameObject.transform.localScale = new Vector3(1.5f, 1.5f);
                ImageEast.gameObject.transform.localScale = new Vector3(1f, 1f);
                ImageWest.gameObject.transform.localScale = new Vector3(1f, 1f);
                break;

            case "East":
                ImageNorth.gameObject.transform.localScale = new Vector3(1f, 1f);
                ImageEast.gameObject.transform.localScale = new Vector3(1.5f, 1.5f);
                ImageWest.gameObject.transform.localScale = new Vector3(1f, 1f);
                break;

            case "West":
                ImageNorth.gameObject.transform.localScale = new Vector3(1f, 1f);
                ImageEast.gameObject.transform.localScale = new Vector3(1f, 1f);
                ImageWest.gameObject.transform.localScale = new Vector3(1.5f, 1.5f);
                break;
        }
    }

    private void UpdateGameManager()
    {
        if (GameManager.Instance.PickedUpCostumersP1 == GameManager.Instance.TargetCounter || GameManager.Instance.PickedUpCostumersP2 == GameManager.Instance.TargetCounter)
        {
            if (GameManager.Instance.PickedUpCostumersP1 == GameManager.Instance.TargetCounter)
            {
                GameManager.Instance.HasWonP1 = true;
                GameManager.Instance.HasWonP2 = false;
            }
            else
            {
                GameManager.Instance.HasWonP2 = true;
                GameManager.Instance.HasWonP1 = false;
            }
            GameManager.Instance.IsGameOver = true;
        }
    }
}
