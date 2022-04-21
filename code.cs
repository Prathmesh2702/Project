using System;
using System.Collections.Generic;
using System.IO;

namespace Wiproproject
{
   internal class Program
    {
        static List<Teacher> listTeachers = new List<Teacher>();

        static void Main(string[] args)
        {
            string UIId = "";
            string UIFirstName = "";
            string UILastName = "";
            string UIClass = "";
            string UISection = "";

            using (FileStream fs = new FileStream(@"C:\Project\Teacher.txt", FileMode.Open))
            using (StreamReader sr = new StreamReader(fs))
            {
                string content = sr.ReadToEnd();
                string[] lines = content.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

                List<Teacher> listTeachers = new List<Teacher>();
                foreach (string line in lines)
                {
                    string[] column = line.Split(',');

                    Teacher teacher = new Teacher();
                    teacher.Id = column[0];
                    teacher.FirstName = column[1];
                    teacher.LastName = column[2];
                    teacher.CClass = column[3];
                    teacher.Section = column[4];
                    listTeachers.Add(teacher);
                }
                Console.WriteLine(content);
            }
            Console.WriteLine("Rainbow School's Teacher Records\n1.update\n2.delete\n3.search\n4.display\n5.save");
            Console.WriteLine("Enter option:");
            int option = Convert.ToInt32(Console.ReadLine());
            InvalidOperationException(option);
            static void update()
            {
                string UIId = "";
                string UIFirstName = "";
                string UILastName = "";
                string UIClass = "";
                string UISection = "";
                using (FileStream fs = new FileStream(@"C:\Project\Teacher.txt", FileMode.Append))
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    Teacher teacher = new Teacher();
                    teacher.Id = UIId;
                    teacher.FirstName = UIFirstName;
                    teacher.LastName = UILastName;
                    teacher.CClass = UIClass;
                    teacher.Section = UISection;

                    Console.WriteLine("Enter data to update:");

                    Console.WriteLine("Enter Teacher Id:");
                    UIId = Console.ReadLine();
                    Console.WriteLine("Enter Teacher First name:");
                    UIFirstName = Console.ReadLine();
                    Console.WriteLine("Enter Teacher Last name:");
                    UILastName = Console.ReadLine();
                    Console.WriteLine("Enter Teacher Class:");
                    UIClass = Console.ReadLine();
                    Console.WriteLine("Enter Teacher Section:");
                    UISection = Console.ReadLine();


                    string fullText = (UIId + "," + UIFirstName + "," + UILastName + "," + UIClass + "," + UISection);
                    sw.WriteLine(fullText);
                    Console.ReadLine();
                }
            }
            static void delete()
            {

                string id;
                Console.WriteLine("Enter Id to delete:");
                id = Console.ReadLine();
                foreach (Teacher t in listTeachers)
                {
                    if (t.Id == id)
                    {
                        listTeachers.Remove(t);
                        break;
                    }
                }
            }
            static void save()
            {
                int count = 0;
                string[] arr = new string[listTeachers.Count];
                foreach (Teacher t in listTeachers)
                {
                    string s = $"{t.Id},{t.FirstName},{t.LastName},{t.CClass},{t.Section}";
                    arr[count] = s;
                    count++;
                }
                File.WriteAllLines(@"C:\Project\teacher.txt", arr);
            }
            static void display()
            {
                List<Teacher> listTeachers1 = new List<Teacher>();
                string teacherfile = "C:\\Project\\Teacher.txt";
                string[] arrteacher = System.IO.File.ReadAllLines(teacherfile);

                foreach (string line in arrteacher)
                {
                    string[] l = line.Split(',');
                    Teacher teacher = new Teacher();
                    teacher.Id = l[0];
                    teacher.FirstName = l[1];
                    teacher.LastName = l[2];
                    teacher.CClass = l[3];
                    teacher.Section = l[4];
                    listTeachers1.Add(teacher);
                }
                foreach (Teacher s in listTeachers1)
                {
                    Console.WriteLine($"{s.Id},{s.FirstName},{s.LastName},{s.CClass},{s.Section}");
                }
            }
            //while (true)
            
                static void Operation(int option, string UIClass)
                {
                    switch (option)
                    {
                        case 1:
                            update();
                            break;
                        case 2:
                            delete();
                            break;
                        case 3:
                            search();
                            break;
                        case 4:
                            display();
                            break;
                        case 5:
                            save();
                            break;
                        default:
                            Console.WriteLine("Invalid");
                            break;
                    }
                }
            
        }

        private static void InvalidOperationException(int option)
        {
            throw new NotImplementedException();
        }

        private static void Operation(int option)
        {
            throw new NotImplementedException();
        }

        private static void search()
        {
            throw new NotImplementedException();
        }
    }
}
