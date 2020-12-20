using Caliburn.Micro;
using KissTheCook.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KissTheCook.WPF.Models
{
    public class IngredientListModel : PropertyChangedBase
    {
        private bool _isSelected;

        public int Id { get; set; }
        public string Name { get; set; }

        public bool IsSelected
        {
            get { return _isSelected; }
            set
            {
                _isSelected = value;
                NotifyOfPropertyChange(() => IsSelected);
            }
        }

        public IngredientListModel(int id, string name, bool isSelected = false)
        {
            Id = id;
            Name = name;
            IsSelected = isSelected;
        }
    }
}
