using static fpxml.Service.MusicSchoolService;
using fpxml.Model;

namespace fpxml
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            CreateXMLIfNotExists();
            // InsertClassroom("guitar jazz");
            // AddTeacher("guitar jazz", "yossi levi");
            // AddStudent("guitar jazz", "ofer badash", "guitar");
            AddManyStudents(
                "guitar jazz",
                new Student("itshak", new Instrument("piano")),
                new Student("noa klein", new Instrument("guitar"))
            );
        }
    }
}
