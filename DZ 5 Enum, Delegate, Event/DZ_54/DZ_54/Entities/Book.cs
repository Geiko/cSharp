using System;
using System.ComponentModel;

namespace geiko.DZ_54.Entities
{
    class Book : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;


        public Author Writer { get; set; }
        public string Title { get; set; }



        private Boolean available;
        public Boolean Available 
        {
            get { return available; }
            set
            {
                available = value;
                if (available == true) OnAvailableChanged();
            }
        }

        public virtual void OnAvailableChanged()
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs("Available"));
        }




        public Book(Author writer, string title)
        {
            this.Writer = writer.DeepCopy(writer);
            this.Title = title;
            this.Available = true;
        }
        
        public override string ToString()
        {
            return string.Format("\"{1}\" by {0}", Writer.Name, Title);
        }        
    }
}
