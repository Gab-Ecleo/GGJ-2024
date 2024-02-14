using UnityEngine;
using UnityEngine.SceneManagement;

public class ContinueToCredits : StateMachineBehaviour
{
    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        SceneManager.LoadScene("Credits");
    }
}
