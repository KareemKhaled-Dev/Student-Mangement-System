using static Student_Manage_System.Student;

namespace Student_Manage_System
{
    public class Student
    {
        public int StudentId;
        public string name;
        public int age;
        List<Course> courses;

        public Student(int studentId, string name, int age)
        {
            StudentId = studentId;
            this.name = name;
            this.age = age;
            courses = new List<Course>();
        }
        public bool Enroll(Course course)
        {

            for (int i = 0; i < courses.Count; i++)
            {

                if (courses[i].CourseId == course.CourseId)
                {
                    return false;
                }
            }
            courses.Add(course);
            return true;
        }
        public string PrintDetails()
        {
            string result = $"ID: {StudentId},Name: {name}, Age: {age}";
            return result;
        }
        public class Instructor
        {
            public int InstructorId;
            public string name;
            public string Specialization;

            public Instructor(int instructorId, string name, string specialization)
            {
                InstructorId = instructorId;
                this.name = name;
                Specialization = specialization;
            }
            public string PrintDetails()
            {
                string result = $"ID: {InstructorId}, Name: {name}, Specialization: {Specialization}";
                return result;

            }
        }
        public class Course
        {
            public int CourseId;
            public string Title;
            public Instructor Instructor;

            public Course(int courseId, string title, Instructor instructor)
            {
                CourseId = courseId;
                Title = title;
                Instructor = instructor;
            }
            public string PrintDetails()
            {
                string result = $"CourseId: {CourseId}, Title: {Title}, Instructor {Instructor.name}";

                return result;
            }

        }
        public class StudentManager
        {
            List<Student> students;
            List<Course> courses;
            List<Instructor> instructors;

            public StudentManager(List<Student> students, List<Course> courses, List<Instructor> instructors)
            {
                this.students = students;
                this.courses = courses;
                this.instructors = instructors;
            }
            public bool AddStudent(Student student)
            {
                for (int i = 0; i < students.Count; i++)
                {
                    if (students[i].StudentId == student.StudentId)
                    {
                        return false;
                    }
                }
                students.Add(student);
                return true;
            }

            public bool AddCourse(Course course)
            {
                for (int i = 0; i < courses.Count; i++)
                {
                    if (courses[i].CourseId == course.CourseId)
                    {
                        return false;
                    }
                }
                courses.Add(course);
                return true;
            }
            public bool AddInstructor(Instructor instructor)
            {
                for (int i = 0; i < instructors.Count; i++)
                {
                    if (instructors[i].InstructorId == instructor.InstructorId)
                    {
                        return false;
                    }
                }
                instructors.Add(instructor);
                return true;
            }
            public Student FindStudent(int StudentId)
            {

                Student result = null;
                for (int i = 0; i < students.Count; i++)
                {
                    if (students[i].StudentId == StudentId)
                    {
                        result = students[i];
                        return result;

                    }

                }
                if (result == null)
                {
                    Console.WriteLine("Student not found");
                }
                return result;
            }

            public Course FindCourse(int CourseId)

            {
                Course result = null;
                for (int i = 0; i < courses.Count; i++)
                {
                    if (courses[i].CourseId == CourseId)
                    {
                        result = courses[i];
                        return result;

                    }

                }
                if (result == null)
                {
                    Console.WriteLine("course not found");
                }
                return result;
            }
            public Instructor FindInstructor(int InstructorId)

            {
                Instructor result = null;
                for (int i = 0; i < instructors.Count; i++)
                {
                    if (instructors[i].InstructorId == InstructorId)
                    {
                        result = instructors[i];
                        return result;

                    }

                }
                if (result == null)
                {
                    Console.WriteLine("instructor not found");
                }
                return result;
            }
            public bool EnrollStudentInCourse(int StudentId, int CourseId)
            {
                Student student = FindStudent(StudentId);
                Course course = FindCourse(CourseId);


                if (FindStudent(StudentId) != null && FindCourse(CourseId) != null)
                {

                    return student.Enroll(course);
                }
                else
                    return false;
            }
            public bool IsStudentEnrolled(int StudentId, int CourseId)
            {
                Student student = FindStudent(StudentId);
                if (student != null)
                {
                    for (int i = 0; i < student.courses.Count; i++)
                    {

                        if (student.courses[i].CourseId == CourseId)
                        {
                            return true;
                        }
                    }
                }

                return false;

            }


        }

        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();
            List<Course> courses = new List<Course>();
            List<Instructor> instructors = new List<Instructor>();

            StudentManager manager = new StudentManager(students, courses, instructors);
            int choose;


            do
            {
                Console.WriteLine("===== Student Management System =====");
                Console.WriteLine("1 - Add Student");
                Console.WriteLine("2 - Add Instructor");
                Console.WriteLine("3 - Add Course");
                Console.WriteLine("4 - Find Student");
                Console.WriteLine("5 - Find Course");
                Console.WriteLine("6 - Find Instructor");
                Console.WriteLine("7 - Enroll Student In Course");
                Console.WriteLine("8 - Check Student Enrollment");
                Console.WriteLine("9 - Show All Students");
                Console.WriteLine("10 - Show All Courses");
                Console.WriteLine("11 - Show All Instructors");
                Console.WriteLine("0 - Exit");

                Console.Write("Enter your choose: ");
                 choose = Convert.ToInt32(Console.ReadLine());

                switch (choose)
                {
                    case 1:
                        {
                            Console.Write("Enter Student ID: ");
                            int id = Convert.ToInt32(Console.ReadLine());

                            Console.Write("Enter Student Name: ");
                            string name = Console.ReadLine();

                            Console.Write("Enter Student Age: ");
                            int age = Convert.ToInt32(Console.ReadLine());

                            Student student = new Student(id, name, age);

                            if (manager.AddStudent(student) == true)
                            {
                                Console.WriteLine("Student added");
                            }
                            else
                            {
                                Console.WriteLine("Student already founded");
                            }

                            break;
                        }

                    case 2:
                        {
                            Console.Write("Enter Instructor ID: ");
                            int id = Convert.ToInt32(Console.ReadLine());

                            Console.Write("Enter Instructor Name: ");
                            string name = Console.ReadLine();

                            Console.Write("Enter Specialization: ");
                            string specialization = Console.ReadLine();

                            Instructor instructor = new Instructor(id, name, specialization);

                            if (manager.AddInstructor(instructor) == true)
                            {
                                Console.WriteLine("Instructor added");
                            }
                            else
                            {
                                Console.WriteLine("Instructor already founded");
                            }

                            break;
                        }

                    case 3:
                        {
                            Console.Write("Enter Course ID: ");
                            int id = Convert.ToInt32(Console.ReadLine());

                            Console.Write("Enter Course Title: ");
                            string title = Console.ReadLine();

                            Console.Write("Enter Instructor ID: ");
                            int instructorId = Convert.ToInt32(Console.ReadLine());

                            Instructor instructor = manager.FindInstructor(instructorId);

                            if (instructor != null)
                            {
                                Course course = new Course(id, title, instructor);

                                if (manager.AddCourse(course) == true)
                                {
                                    Console.WriteLine("Course added ");
                                }
                                else
                                {
                                    Console.WriteLine("Course already founded");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Cannot add course");
                            }

                            break;
                        }

                    case 4:
                        {
                            Console.Write("Enter Student ID: ");
                            int id = Convert.ToInt32(Console.ReadLine());

                            Student student = manager.FindStudent(id);

                            if (student != null)
                            {
                                Console.WriteLine(student.PrintDetails());
                            }

                            break;
                        }

                    case 5:
                        {
                            Console.Write("Enter Course ID: ");
                            int id = Convert.ToInt32(Console.ReadLine());

                            Course course = manager.FindCourse(id);

                            if (course != null)
                            {
                                Console.WriteLine(course.PrintDetails());
                            }

                            break;
                        }

                    case 6:
                        {
                            Console.Write("Enter Instructor ID: ");
                            int id = Convert.ToInt32(Console.ReadLine());

                            Instructor instructor = manager.FindInstructor(id);

                            if (instructor != null)
                            {
                                Console.WriteLine(instructor.PrintDetails());
                            }

                            break;
                        }

                    case 7:
                        {
                            Console.Write("Enter Student ID: ");
                            int studentId = Convert.ToInt32(Console.ReadLine());

                            Console.Write("Enter Course ID: ");
                            int courseId = Convert.ToInt32(Console.ReadLine());

                            if (manager.EnrollStudentInCourse(studentId, courseId) == true)
                            {
                                Console.WriteLine("Enroll successful");
                            }
                            else
                            {
                                Console.WriteLine("Enroll failed");
                            }

                            break;
                        }

                    case 8:
                        {
                            Console.Write("Enter Student ID: ");
                            int studentId = Convert.ToInt32(Console.ReadLine());

                            Console.Write("Enter Course ID: ");
                            int courseId = Convert.ToInt32(Console.ReadLine());

                            if (manager.IsStudentEnrolled(studentId, courseId) == true)
                            {
                                Console.WriteLine("Student is enrolled");
                            }
                            else
                            {
                                Console.WriteLine("Student is not enrolled");
                            }

                            break;
                        }

                    case 9:
                        {
                            for (int i = 0; i < students.Count; i++)
                            {
                                Console.WriteLine(students[i].PrintDetails());
                            }

                            break;
                        }

                    case 10:
                        {
                            for (int i = 0; i < courses.Count; i++)
                            {
                                Console.WriteLine(courses[i].PrintDetails());
                            }

                            break;
                        }

                    case 11:
                        {
                            for (int i = 0; i < instructors.Count; i++)
                            {
                                Console.WriteLine(instructors[i].PrintDetails());
                            }

                            break;
                        }

                    case 0:
                        {
                            Console.WriteLine("Goodbye!");
                            break;
                        }

                    default:
                        {
                            Console.WriteLine("Invalid choose");
                            break;
                        }
                }

               
            } while (choose != 0);
        }
    }
}



