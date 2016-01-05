﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Interfaces.Actions
{
    public class ShowDateAction : IMenuItemSelectedObserver
    {
        /// <summary>
        /// Create a new instance of <see cref="ShowDateAction"/>
        /// </summary>
        public ShowDateAction()
        {
            MenuItem menuItem = new MenuItem("Show Date");
            menuItem.AttachObserver(this);
            m_MenuItems.Add(menuItem);
        }

        /// <summary>
        /// Report on a menu that has selected
        /// </summary>
        /// <param name="i_MenuItem">The selected menu to report on</param>
        public void ReportSelect(MenuItem i_MenuItem)
        {
            Execute();
        }

        /// <summary>
        /// Execute the <see cref="ShowDateAction"/> action.
        /// The actions will display the current date
        /// </summary>
        private void Execute()
        {
            Console.WriteLine("The current data is: {0}", DateTime.Now.ToShortDateString());
        }

        /// <summary>
        /// List of all the menu items that are register for the action
        /// </summary>
        public List<MenuItem> MenuItems
        {
            get
            {
                return m_MenuItems;
            }
        }

        private readonly List<MenuItem> m_MenuItems = new List<MenuItem>();
    }
}
