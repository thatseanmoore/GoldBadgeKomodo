using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeRepo
{
    public class MenuContentRepo
    {
        private List<MenuContent> _menuContent = new List<MenuContent>();

        public void AddMenuContentToList(MenuContent content)
        {
            _menuContent.Add(content);
        }
        public List<MenuContent> GetMenuContentList()
        {
            return _menuContent;
        }
        public bool RemoveMenuContentFromList(MealNumber mealNumber)
        {
            MenuContent content = GetContentByMealNumber(mealNumber);
            if (content == null)
            {
                return false;
            }
            int initialCount = _menuContent.Count;
            _menuContent.Remove(content);

            if (initialCount > _menuContent.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public MenuContent GetContentByMealNumber(MealNumber mealNumber)
        {
            foreach (MenuContent content in _menuContent)
            {
                if (content.MealNumber == mealNumber)
                {
                    return content;
                }
            }
            return null;
        }
    }
}
