//Replace all the text in your MainWindow.xaml.cs with the text below .

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Mod_9_Homework
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    ///
    class Student : IEquatable<Student>
    {
        private string sfName, ssName, sProgram;

        public string SProgram
        {
            get { return sProgram; }
            set
            {
                if (value == "")
                { throw new System.Exception("City can`t be null"); }
                else { sProgram = value; }
            }
        }

        public string SsName
        {
            get { return ssName; }
            set
            {
                if (value == "")
                { throw new System.Exception("Last Name can`t be null"); }
                else { ssName = value; }
            }
        }

        public string SfName
        {
            get { return sfName; }
            set
            {
                if (value == "")
                { throw new System.Exception("Name can`t be null"); }
                else { sfName = value; }
            }
        }

        public Student(string sname, string ssname, string sprogram)
        {
            this.SfName = sname;
            this.SsName = ssname;
            this.SProgram = sprogram;
        }

        public bool Equals(Student other)
        {
            if (this.SfName == other.SfName && this.SsName == other.SsName && this.SProgram == other.SProgram)
            { return true; }
            else
            { return false; }
        }
    }

  public partial class MainWindow : Window
    {

      List<Student> st_list = new List<Student>();
      static int pos = 0;
      static int pos_n = 0;

      public MainWindow()
        {
          InitializeComponent();                               
        }

        private void btnCreateStudent_Click(object sender, RoutedEventArgs e)
        {
            try
            {               
                Student student1 = new Student (txtFirstName.Text, txtLastName.Text, txtProgram.Text);
               
                if (st_list.Contains(student1)) { status_label.Content = "Student already exist"; }
                else 
                {
                    st_list.Add(student1);
                    
                    pos = st_list.Count;
                    pos_n = st_list.Count;

                    txtFirstName.Clear();
                    txtLastName.Clear();
                    txtProgram.Clear();
                    status_label.Content = "";
                    //status_label_Copy.Content = pos_n;
                    //cnt_label.Content = st_list.Count;
                  }            
               }
            
            catch ( System.Exception st2)
            {
                status_label.Content = st2.Message;
              }                              
        }

        private void btnPrevious_Click(object sender, RoutedEventArgs e)
        {
            if (st_list.Count == 0) { status_label.Content = "No students exist"; }
            else if ((pos < 0) || (pos == st_list.Count)) { pos = st_list.Count - 1; txt_drower(pos); pos_n = pos; pos--; }
            else { txt_drower(pos); pos_n = pos; pos--;}         
        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {             
             if (st_list.Count == 0) { status_label.Content = "No students exist"; }
             else if ((pos_n < 0) || (pos_n == st_list.Count )) { pos_n = 0; txt_drower(pos_n); pos = pos_n; pos_n++;  }
             else { txt_drower(pos_n); pos = pos_n; pos_n++;}                
         }

        public void txt_drower(int position)
        {
            Student student_tmp = st_list.ElementAt(position);
            txtFirstName.Text = student_tmp.SfName;
            txtLastName.Text = student_tmp.SsName;
            txtProgram.Text = student_tmp.SProgram;
            status_label.Content = "";             
           }
    }
}
