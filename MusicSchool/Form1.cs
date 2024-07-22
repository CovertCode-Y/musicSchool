using MusicSchool.Model;
using static MusicSchool.Service.MusicScoolService;
namespace MusicSchool
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            CreateXMLIfNotExists();
            //     AddStudent("room-10", "moshe", "guitar");
            //     AddStudent("room-10", "chayim", "piano");
            //    InsertClassRoom("room-10");
            //   AddTeacher("room-10", "yosi");
            AddManyStudents("room-10",
                new Student("itzik", new Instrument("piano"),
                new Student("noha", new Instrument("piano"))));
        }
    }
}
