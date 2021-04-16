﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace MVVM.ViewModel
{
    public class StartViewModel : INotifyPropertyChanged
    {
        public CustomCommand LadeDbCmd { get; set; }
        public CustomCommand OeffeneDbCmd { get; set; }

        public int AnzahlPersonen { get { return Model.Person.Personenliste.Count; } }

        public StartViewModel()
        {
            LadeDbCmd = new CustomCommand
                (
                p =>
                {
                    Model.Person.LadePersonenAusDb();
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(AnzahlPersonen)));
                },
                p => AnzahlPersonen == 0
                );

            OeffeneDbCmd = new CustomCommand
                (
                    p => { },
                    p => AnzahlPersonen > 0
                );
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
