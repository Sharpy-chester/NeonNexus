using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Menu
{
    public class SkillTree : MonoBehaviour
    {
        [SerializeField] List<Skill> skillList;
        List<Item> purchasedSkills;
        [SerializeField] SkillHandler skillHandler;

        void Start()
        {
            RefreshSkills();
        }

        void Update()
        {

        }

        public void RefreshSkills()
        {
            foreach (Skill s in skillList)
            {
                s.CheckIfUnlockable();
            }
        }

        public void AddItem(Item item)
        {
            bool alreadyHasItem = false;
            if(purchasedSkills != null)
            {
                foreach (Item i in purchasedSkills)
                {
                    if (i == item)
                    {
                        alreadyHasItem = true;
                    }
                }
            }
            else
            {
                purchasedSkills = new List<Item>();
            }
            if (!alreadyHasItem)
            {
                purchasedSkills.Add(item);
                skillHandler.AddItems(item);
            }

        }
    }
}
