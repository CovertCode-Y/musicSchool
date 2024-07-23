using fpxml.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static fpxml.Configuration.MusicSchoolConfiguration;

namespace fpxml.Service
{
    internal static class MusicSchoolService
    {

	public static void Enosh() 
	{
	}
	    
        public static void CreateXMLIfNotExists()
        {
            if (!File.Exists(musicSchoolPath))
            {
                // create new document (xml)
                XDocument document = new();
                // create an element 
                XElement musicSchool = new("music-school");
                // document add element
                document.Add(musicSchool);
                // document save changes to provided path
                document.Save(musicSchoolPath);
            }
        }

        // <student name="ofer"><instrument>guitar...</ </
        private static XElement ConverStudentToElement(Student student) =>
            new(
                "student",
                new XAttribute("name", student.Name),
                new XElement("instrument", student.Instrument.Name)
            );

        public static void AddManyStudents(
            string classRoomName, params Student[] students
        )
        {
            XDocument document = XDocument.Load(musicSchoolPath);

            XElement? classRoom = document.Descendants("class-room")
                .FirstOrDefault(room => room.Attribute("name")?.Value == classRoomName);

            if (classRoom == null) { return; }

            List<XElement> studentsList = students
                .Select(ConverStudentToElement)
                .ToList();

            classRoom.Add(studentsList);

            document.Save(musicSchoolPath);
        }

        public static void AddStudent(
            string classRoomName, string studentName, string instrumentName
        )
        {

            /*  <student name="enosh">
             *      <instrument>
             *          guitar
             *      </instrument>
             *  </student>
             */
            // new XElemnt("instument", new XElement("guitar"))

            // load documents
            XDocument document = XDocument.Load(musicSchoolPath);
            // find the specific class-room by attribute's name
            XElement? classRoom = (
                from room in document.Descendants("class-room")
                where room.Attribute("name")?.Value == classRoomName
                select room
            ).FirstOrDefault();
            // check if not null
            if (classRoom == null) { return; }

            // create XElement of instrument <instrument>guitar</instrument>
            XElement instrument = new("instrument", instrumentName);
            XAttribute studentAttribute = new("name", studentName);
            // create XElement of student with attribute name
            XElement student = new("student", studentAttribute, instrument);
            // add instrument to student 

            student.SetAttributeValue("name", "elly");
            instrument.Value = "piano";
            student.ReplaceWith(new XElement("adsd", ""));


            // add student to class-room
            classRoom.Add(student);
            // save changes
            document.Save(musicSchoolPath);
        }

        public static void AddTeacher(
            string classRoomName, string teacherName
        )
        {
            // load documents
            XDocument document = XDocument.Load(musicSchoolPath);
            // find the specific class-room by attribute name = classRoomName
            XElement? classRoom = document.Descendants("class-room")
                .FirstOrDefault(room =>
                    room.Attribute("name")?.Value == classRoomName
                );
            if (classRoom == null)
            {
                return;
            }
            // create new XElement teacher with attribute name = teacherName
            XElement teacher = new(
                "teacher",
                new XAttribute("name", teacherName)
            );
            // add teacher to the class-room
            classRoom.Add(teacher);
            // save document
            document.Save(musicSchoolPath);
        }

        public static void InsertClassroom(string classRoomName)
        {
            // load document
            XDocument document = XDocument.Load(musicSchoolPath);

            // find music-school ( root )
            XElement? musicSchool = document.Descendants("music-school")
                .FirstOrDefault();


            // validate music-school existence
            if (musicSchool == null)
            {
                return;
            }

            // create new x element (class-room)
            // <class-room name="guitar one on one">
            XElement classRoom = new(
                "class-room",
                new XAttribute("name", classRoomName)

            );
            // add to music-school new class-room
            musicSchool.Add(classRoom);

            // document save
            document.Save(musicSchoolPath);
        }
    }
}
