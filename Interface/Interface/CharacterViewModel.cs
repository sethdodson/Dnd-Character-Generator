using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Collections.ObjectModel;

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
                RaisePropertyChanged("Alignment");
                RaisePropertyChanged("Height");
                RaisePropertyChanged("MaxSpellLevel");
            }
        }

        public string Name { get; set; }
        public string Alignment { get { return String.Format("{0} / {1}", _characterModel.Legality.Name, _characterModel.Morality.Name); } }
        public string PlayerName { get; set; }

        public string Height
        {
            get
            {
                var feet = Math.Floor(_characterModel.Height / 12f);
                var inches = _characterModel.Height % 12;
                return String.Format("{0}' {1}''", feet, inches);                
            }
        }

        public int MaxSpellLevel { get { return _characterModel.MaxSpellLevel == null ? 0 : _characterModel.MaxSpellLevel.Value; } }

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
