using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Animation 
{

    public enum AnimationType
    {
        NONE,
        IDLE,
        RUN,
        ATTACK,
        DEATH
    }
    public class AnimationBase : MonoBehaviour
    {
        public Animator animator;
        public List<animationSetup> animationSetups;

        public void PlayAnimationByTrigger(AnimationType animationType)
        {

            var setup = animationSetups.Find(i => i.animationType == animationType);
            if (setup != null)
            {
                animator.SetTrigger(setup.trigger);
            }

        }



    }

    [System.Serializable]
    public class animationSetup
    {
        public AnimationType animationType;
        public string trigger;

    }
}
