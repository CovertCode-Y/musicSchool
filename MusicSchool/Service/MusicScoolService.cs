using MusicSchool.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static MusicSchool.Configuration.MusicSchoolConfiguration;

namespace MusicSchool.Service
{
    internal static class MusicScoolService
    {
        public static void CreateXMLIfNotExists()
        {
            if(!File.Exists(musicSchoolPath))
            {
                //create new document xml
                XDocument document = new ();
                //create an element
                XElement musicSchool = new("music-School");
                //document add element
                document.Add(musicSchool);
                //document save changes to provided path
                document.Save(musicSchoolPath);



            }
        }

      

        public static void AddStudent
          (string classRoomName, string studentName ,string instrumentName)
        {
        XDocument document = XDocument.Load(musicSchoolPath);
            XElement? classRoom = document.Descendants("class-room")
                .FirstOrDefault(root => root.Attribute("name")?.Value
                == classRoomName);
            if(classRoom == null)
            {
                return;
            }

            XElement instrument = new("instrument", instrumentName);



            XElement student = new("student" , 
                new XAttribute("name", studentName),
                new XElement("instrument" , instrumentName)
                );
         //   student.SetAttributeValue("name", "elly");
         //   instrument.Value = "piano";
         //   student.ReplaceWith(new XElement("asda", " "));
            classRoom.Add(student);
            document.Save(musicSchoolPath);

        }

        public static void AddTeacher
            ( string classRoomName , string teacherName)
        {
            XDocument document = XDocument.Load(musicSchoolPath);
            XElement? musicSchool = document.Descendants("class-room").
                FirstOrDefault(root => root.Attribute("name")?.Value ==
                classRoomName);
            if (musicSchool == null)
            {
                return;
            }
            XElement teacher = new(
                "teacher",
                new XAttribute("name", teacherName)
            );
            musicSchool.Add(teacher);
            document.Save(musicSchoolPath);

        }


        public static void InsertClassRoom(string classRoomName)
        {
            XDocument document = XDocument.Load(musicSchoolPath);

            XElement? musicSchool = document.Descendants("music-School").
                FirstOrDefault();

            if (musicSchool == null)
            {
                return;
            }
            XElement classRoom = new (
                "class-room", 
                new XAttribute("name", classRoomName)
            );
            musicSchool.Add(classRoom);
            document.Save(musicSchoolPath);
        }
        private static XElement ConvertStudentToElement(Student student)
            => new("student", new XAttribute("name", student.Name),
                new XElement("instrument", student.Instrument.Name)
                );
        public static void AddManyStudents
            (string classRoomName, params Student[] students)
        {
            XDocument document = XDocument.Load(musicSchoolPath);
            XElement? classRoom = document.Descendants("class-room")
                .FirstOrDefault(root => root.Attribute("name")?.Value
                 == classRoomName);
            if (classRoom == null)
            {
                return ;
            }
            List<XElement> studentsList = students.Select(ConvertStudentToElement)
                .ToList();
           
            classRoom.Add(studentsList);
            document.Save(musicSchoolPath);
        }
    }
}
