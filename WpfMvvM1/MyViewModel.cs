using System;
using System.ComponentModel;

namespace WpfMvvM1
{
    sealed class MyViewModel : INotifyPropertyChanged
    {
        private User user;

        public string FirstName
        {
            get { return user.FirstName    ; }
            set
            {
                if (user.FirstName != value)
                {
                    user.FirstName = value;
                    OnPropertyChange("FirstName");
                    //.................................
                    OnPropertyChange("FullName");
                }
            }
        }

        public string LastName
        {
            get { return user.LastName; }
            set
            {
                if (user.LastName != value)
                {
                    user.LastName = value;
                    OnPropertyChange("LastName");
                    //.................................
                    OnPropertyChange("FullName");
                }
            }
        }

         public int Age
        {    get { return   user.Age; }
            set
            {
                user.Age = (short)value;
                OnPropertyChange("LastName");
                //.................................
                OnPropertyChange("FullName"); 
                //.................................
                OnPropertyChange("Age");
            }
        }
           
      

         public string FullName
        {
            get { return FirstName + " " + LastName + " ( " + Age.ToString() + " ) "; }
        }

        public MyViewModel()
        {
            user = new User
            {
                FirstName = " ",
                LastName = " ",
                BirthDate = DateTime.Now.AddYears(-30),
                Age=0
            };
        }

         public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChange(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }




    }

}
