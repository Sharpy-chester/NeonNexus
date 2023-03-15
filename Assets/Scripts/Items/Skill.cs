using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Menu
{
    public class Skill : MonoBehaviour
    {
        public bool unlocked;
        public bool purchased;

        [SerializeField] int unlockCost;

        [SerializeField] List<Skill> requiredSkills;
        List<Skill> requiredFor;

        [SerializeField] Color lockedColour;
        [SerializeField] Color unlockedColour;
        [SerializeField] Color purchasedColour;
        [SerializeField] Button button;

        [SerializeField] Image tile;
        [SerializeField] Sprite image;

        [SerializeField] SkillTree skillTree;

        [SerializeField] Item itemToGivePlayer;

        [SerializeField] Image icon;
        Nexbit nexbitManager;

        void Awake()
        {
            tile = GetComponent<Image>();
            CheckIfUnlockable();
            icon.sprite = itemToGivePlayer.IconSprite;
            nexbitManager = FindObjectOfType<Nexbit>();
        }

        private void Update()
        {

        }

        public void CheckIfUnlockable()
        {
            unlocked = true;
            if (!purchased)
            {
                if (requiredSkills != null)
                {
                    foreach (Skill s in requiredSkills)
                    {
                        if (s.purchased == false)
                        {
                            unlocked = false;
                        }
                    }
                }
                tile.color = unlocked ? unlockedColour : lockedColour;
            }
            button.enabled = unlocked;
        }

        public void Purchase()
        {
            if(!purchased && (nexbitManager.nexbits - unlockCost) > 0)
            {
                purchased = true;
                nexbitManager.RemoveNexbits(unlockCost);
                skillTree.RefreshSkills();
                tile.color = purchasedColour;
                skillTree.AddItem(itemToGivePlayer);
            }
        }
    }
}

