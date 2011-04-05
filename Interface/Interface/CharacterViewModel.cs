using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace Interface
{
    public class CharacterViewModel : INotifyPropertyChanged
    {
        private CharacterGenerator.CharacterModel _characterModel;

        public CharacterGenerator.CharacterModel CharacterModel
        {
            get { return _characterModel; }
            set
            {
                if (value == _characterModel) return;
                _characterModel = value;
                RaisePropertyChanged("CharacterModel");
            }
        }

        public string Name { get; set; }

        public CharacterViewModel()
        {
            _characterModel = CharacterGenerator.getCharacter(1);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
